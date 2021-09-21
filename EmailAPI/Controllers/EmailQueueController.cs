using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Consts;
using Core.Models;
using Core.Services;
using EmailAPI.DTO.EmailQueue;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailQueueController : ControllerBase
    {
        private readonly IService<EmailQueue> queueProviderService;
        private readonly IMapper mapper;
        private readonly IDapperService<EmailQueue> queueProviderDapperService;

        public EmailQueueController(IService<EmailQueue> queueSrvc, IDapperService<EmailQueue> queueDapperSrvc, IMapper mapperSrvc)
        {
            queueProviderService = queueSrvc;
            queueProviderDapperService = queueDapperSrvc;
            mapper = mapperSrvc;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Email Queue tablosunu Getirir", Description = "Email Queue tablosunu Getirir")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //var test = (await queueProviderDapperService.QueryAsync($"SELECT * FROM EmailQueue")).ToList();
                var result = await queueProviderService.GetAllAsync();
                return Ok(new Result<IEnumerable<EmailQueueDto>>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, mapper.Map<IEnumerable<EmailQueueDto>>(result)));
            }
            catch (Exception e)
            {
                return NotFound(new Result<IEnumerable<EmailQueueDto>>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Email Queue tablosuna kayıt atar", Description = "Email Queue tablosuna kayıt atar")]
        [Authorize]
        public async Task<IActionResult> SaveEmailQueue(SaveEmailQueueDto dto)
        {
            try
            {
                var emailQueueEntity = mapper.Map<EmailQueue>(dto);
                (emailQueueEntity.Dates ??= (new List<EmailDate>() { })).Add(new EmailDate());
                if (emailQueueEntity.Dates.Count > 1)
                {
                    int countEmptyDate = emailQueueEntity.Dates.Where(x => x.When == null).Count();
                    if (countEmptyDate > 0)
                    {
                        // eger tarihleri dolu ise hepsine ait when olmak zorunda. 
                        return Ok(new Result<EmailQueue>(isSuccess: false, ResultType.Warning,
                            "Birden fazla mesaj gönderme işlemi için tarih girilmesi zorunludur.", null));
                    }
                }
                var entity = await queueProviderService.AddAsync(emailQueueEntity);
                return Ok(new Result<EmailQueue>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, mapper.Map<EmailQueue>(entity)));
            }
            catch (Exception e)
            {

                return NotFound(new Result<EmailQueue>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }

        }



    }
}
