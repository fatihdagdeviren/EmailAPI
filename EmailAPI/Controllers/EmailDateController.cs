using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Consts;
using Core.Models;
using Core.Services;
using EmailAPI.DTO.EmailDate;
using EmailAPI.DTO.EmailQueue;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailDateController : Controller
    {
        private readonly IService<EmailDate> emailDateService;
        private readonly IMapper mapper;
        private readonly IDapperService<EmailDate> emailDateDapperService;

        public EmailDateController(IService<EmailDate> Srvc, IDapperService<EmailDate> dapperSrvc, IMapper mapperSrvc)
        {
            emailDateService = Srvc;
            emailDateDapperService = dapperSrvc;
            mapper = mapperSrvc;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Email Dates tablosunu Getirir", Description = "Email Dates tablosunu Getirir")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await emailDateService.GetAllAsync();
                return Ok(new Result<IEnumerable<EmailDateDto>>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, mapper.Map<IEnumerable<EmailDateDto>>(result)));
            }
            catch (Exception e)
            {
                return NotFound(new Result<IEnumerable<EmailDateDto>>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Email Dates tablosunu Getirir", Description = "Email Dates tablosunu Getirir")]
        [Authorize]
        public async Task<IActionResult> GetByEmailQueueId(GetEmailDateByEmailQueueDto dto)
        {
            try
            {
                var result = await emailDateService.Where(x => x.EmailQueueId == dto.Id);
                return Ok(new Result<IEnumerable<EmailDateDto>>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, mapper.Map<IEnumerable<EmailDateDto>>(result)));
            }
            catch (Exception e)
            {
                return NotFound(new Result<IEnumerable<EmailDateDto>>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Email Dates tablosuna kayıt atar", Description = "Email Dates tablosuna kayıt atar")]
        [Authorize]
        public async Task<IActionResult> SaveEmailDate(SaveEmailDateDto dto)
        {
            try
            {
                var apiEntity = mapper.Map<EmailDate>(dto);
                var entity = await emailDateService.AddAsync(apiEntity);
                return Ok(new Result<EmailDate>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, mapper.Map<EmailDate>(entity)));
            }
            catch (Exception e)
            {

                return NotFound(new Result<EmailDate>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Email Dates tablosundaki kaydı siler", Description = "Email Dates tablosundaki kaydi siler")]
        [Authorize]
        public async Task<IActionResult> DeleteEmailDateById(DeleteEmailDateDto dto)
        {
            try
            {
                var entity = await emailDateService.GetByIdAsync(dto.Id);
                entity.IsDeleted = true;
                entity.DeletionTime = DateTime.Now;
                emailDateService.Update(entity);
                return Ok(new Result<EmailDate>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, mapper.Map<EmailDate>(entity)));
            }
            catch (Exception e)
            {

                return NotFound(new Result<EmailDate>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }

        }


    }
}
