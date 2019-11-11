using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Commands.JobManager.AddJob;
using SpeekIO.Application.Commands.JobManager.UpdateJob;
using SpeekIO.Application.Queries.Job;
using SpeekIO.Application.Queries.Job.GetEmploymentTypes;
using SpeekIO.Application.Queries.Job.GetJobCategoryList;
using SpeekIO.Application.Queries.Job.GetLanguageList;
using SpeekIO.Application.Queries.Job.GetQualificationList;
using SpeekIO.Application.Queries.JobManager.GetJob;
using SpeekIO.Application.Queries.JobManager.GetJobList;
using SpeekIO.Domain.ViewModels.Response.GetJobResponse;
using SpeekIO.Domain.ViewModels.Response.JobsResponse;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.CommandResponse;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.QueryResponse;

namespace SpeekIO.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class JobController : SpeekIOController
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
            try
            {
                var response = await _mediator.Send(getJobCommand);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return new GetJobResponse()
                {
                    Successful = false,
                    Message = "Something went wrong. Please try again."
                };
            }
        }

        [HttpGet(nameof(GetEmploymentTypeList))]
        [ResponseCache(Duration = 21600)]
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

        [HttpGet(nameof(GetJobCategoryList))]
        [ResponseCache(Duration = 21600)]
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

        [HttpGet(nameof(GetQualificationList))]
        [ResponseCache(Duration = 21600)]
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


        [HttpGet(nameof(GetJobDropDownsList))]
        [ResponseCache(Duration = 21600)]
        public async Task<ActionResult> GetJobDropDownsList()
        {
            try
            {
                var employmentTypeList = await _mediator.Send(new GetAllEmploymentTypesQuery());
                var categoryList = await _mediator.Send(new GetJobCategoryListQuery());
                var qualificationList = await _mediator.Send(new GetQualificationListQuery());
                var languageList = await _mediator.Send(new GetLanguageListQuery());

                return new JsonResult(new
                {
                    employmentTypeList,
                    categoryList,
                    qualificationList,
                    languageList,
                    Successful = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return new JsonResult(new
                {
                    Successful = false,
                    Message = "Something went wrong. Please try again"
                });
            }
        }


        [HttpPost]
        [Route("SaveJob")]
        public async Task<AddJobResponse> SaveJob(AddJobCommand model)
        {
            try
            {
                var job = await _mediator.Send(model);
                return job;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return new AddJobResponse()
                {
                    Successful = false,
                    Message = "Something went wrong. Please try again"
                };
            }
        }

        [HttpPost]
        [Route("UpdateJob")]
        public async Task<AddJobResponse> UpdateJob([FromBody]UpdateJobCommand command)
        {
            try
            {
                var job = await _mediator.Send(command);
                return job;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return new AddJobResponse()
                {
                    Successful = false,
                    Message = "Something went wrong. Please try again"
                };
            }
        }

        [HttpPost(nameof(GetJobs))]
        public async Task<GetJobListResponse> GetJobs(GetJobListQuery query)
        {
            try
            {
                var jobs = await _mediator.Send(query);
                return jobs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return new GetJobListResponse()
                {
                    Successful = false,
                    Message = "Something went wrong. Please try again"
                };
            }
        }


    }
}