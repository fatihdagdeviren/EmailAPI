using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Consts;
using Core.Models;
using Core.Services;
using EmailAPI.DTO.EmailAttachment;
using EmailAPI.DTO.EmailProvider;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace EmailAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmailAttachmentController : ControllerBase
    {
        private readonly IService<EmailAttachment> attachmentService;
        private readonly IMapper mapper;
        private readonly IDapperService<EmailAttachment> attachmentDapperService;


        public EmailAttachmentController(IService<EmailAttachment> Srvc, 
            IDapperService<EmailAttachment> DapperSrvc, IMapper mapperSrvc)
        {
            attachmentService = Srvc;
            attachmentDapperService = DapperSrvc;
            mapper = mapperSrvc;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Email Attachmentlerini getirir.", Description = "Email Attachmentlerini getirir.")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var attachments = await attachmentService.GetAllAsync();
                return Ok(new Result<IEnumerable<EmailAttachmentDto>>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, mapper.Map<IEnumerable<EmailAttachmentDto>>(attachments)));
            }
            catch (Exception e)
            {
                return NotFound(new Result<IEnumerable<EmailAttachmentDto>>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Email Attachmentlerini Kaydeder", Description = "Email Attachmentlerini Kaydeder")]
        [Authorize]
        public async Task<IActionResult> SaveEmailAttachments(List<SaveEmailAttachmentDto> dto)
        {
            try
            {
                var newEntity = mapper.Map<List<EmailAttachment>>(dto);
                var entity = await attachmentService.AddRangeAsync(newEntity);
                return Ok(new Result<IEnumerable<EmailAttachment>>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, entity));

             
            }
            catch (Exception e)
            {
                return NotFound(new Result<IEnumerable<EmailAttachment>>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }

        }


        [HttpGet]
        [SwaggerOperation(Summary = "Queue id'sine ait olan attachmentleri getirir.", Description = "Queue id'sine ait olan attachmentleri getirir.")]
        [Authorize]
        public async Task<IActionResult> GetEmailAttachmentsByEmailQueueId(Guid id)
        {
            try
            {
                var attachments = await attachmentService.Where(x=>x.EmailQueueId == id);
                return Ok(new Result<IEnumerable<EmailAttachment>>(isSuccess: true, ResultType.Success,
                    Const.SuccessMessage, mapper.Map<IEnumerable<EmailAttachment>>(attachments)));
                
            }
            catch (Exception e)
            {
                return NotFound(new Result<IEnumerable<EmailAttachment>>(isSuccess: false, ResultType.Error,
                    e.Message.ToString(), null));
            }

        }



    }
}
