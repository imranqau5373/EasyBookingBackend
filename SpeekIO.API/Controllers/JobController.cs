using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Queries.Job;
using SpeekIO.Application.Queries.Job.GetEmploymentTypes;
using SpeekIO.Application.Queries.Job.GetJobCategoryList;
using SpeekIO.Application.Queries.Job.GetQualificationList;
using SpeekIO.Domain.ViewModels.Response.GetJobResponse;
using SpeekIO.Domain.ViewModels.Response.JobsResponse;

namespace SpeekIO.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<JobController> _logger;

        public JobController(IMediator mediator, ILogger<JobController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(nameof(GetJobById))]
        public async Task<GetJobResponse> GetJobById(GetJobQuery getJobCommand)
        {
            throw new NotImplementedException();
        }

        [HttpPost(nameof(GetEmploymentTypeList))]
        public async Task<GetAllEmploymentTypeListViewModel> GetEmploymentTypeList()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEmploymentTypesQuery());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return new GetAllEmploymentTypeListViewModel()
                {
                    Successful = false,
                    Message = "Something went wrong. Please try again"
                };
            }
        }

        [HttpPost(nameof(GetJobCategoryList))]
        public async Task<GetJobCategoryListResponse> GetJobCategoryList()
        {
            try
            {
                var response = await _mediator.Send(new GetJobCategoryListQuery());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return new GetJobCategoryListResponse()
                {
                    Successful = false,
                    Message = "Something went wrong. Please try again"
                };
            }
        }

        [HttpPost(nameof(GetQualificationList))]
        public async Task<GetQualificationListResponse> GetQualificationList()
        {
            try
            {
                var response = await _mediator.Send(new GetQualificationListQuery());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return new GetQualificationListResponse()
                {
                    Successful = false,
                    Message = "Something went wrong. Please try again"
                };
            }
        }


    }
}