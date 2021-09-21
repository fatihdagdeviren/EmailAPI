using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Consts;
using Core.Models;
using Core.Services;
using EmailAPI.DTO;
using EmailAPI.DTO.EmailProvider;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   
    public class EmailProviderController : ControllerBase
    {
        private readonly IService<EmailProvider> emailProviderService;
        private readonly IMapper mapper;
        private readonly IDapperService<EmailProvider> emailProviderDapperService;

        public EmailProviderController(IService<EmailProvider> emailSrvc,
            IDapperService<EmailProvider> emailDapperSrvc, IMapper mapperSrvc)
        {
            emailProviderService = emailSrvc;
            emailProviderDapperService = emailDapperSrvc;
            mapper = mapperSrvc;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Email Providerlarini Getirir", Description = "Email Providerlarini Getirir")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var providers = await emailProviderService.GetAllAsync();
                return Ok(new Result<IEnumerable<EmailProviderDto>>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, mapper.Map<IEnumerable<EmailProviderDto>>(providers)));
            }
            catch (Exception e)
            {
                return NotFound(new Result<IEnumerable<EmailProviderDto>>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }
          
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Email Providerlarini Kaydeder", Description = "Email Providerlarini Kaydeder")]
        [Authorize]
        public async Task<IActionResult> SaveEmailProvider(SaveEmailProviderDto emailProviderDto)
        {
            try
            {
                var newEntity = mapper.Map<EmailProvider>(emailProviderDto);
                var entity =  await emailProviderService.AddAsync(newEntity);
                return Ok(new Result<EmailProvider>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, entity));

            }
            catch (Exception e)
            {
                return NotFound(new Result<EmailProvider>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }

        }


    }
}
