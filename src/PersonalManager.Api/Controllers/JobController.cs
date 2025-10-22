using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalManager.Api.Model;
using PersonalManager.Application.Dtos;
using PersonalManager.Application.Features.Jobs.Command.CreateJob;
using PersonalManager.Application.Features.Jobs.Command.DeleteJob;
using PersonalManager.Application.Features.Jobs.Command.UpdateJob;
using PersonalManager.Application.Features.Jobs.Query.GetAllJobs;
using PersonalManager.Application.Features.Jobs.Query.GetOneJob;

namespace PersonalManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController(IMediator _mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateJobRequest request)
        {
            JobDto result = await _mediator.Send(new CreateJobCommand()
            {
                JobTitle = request.JobTitle,
                DepartementId = request.DepartementId,
            });

            return Ok(new ApiResponse<JobDto>()
            {
                Code = 200,
                Success = true,
                Data = result,
                Message = "create with success",
                Meta = null
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteJobCommand request)
        {
            await _mediator.Send(new DeleteJobCommand() { Id = request.Id });
            return Ok(new ApiResponse<JobDto>
            {
                Code = 200,
                Success = true,
                Data = null,
                Message = "Delete with success",
                Meta = null
            });
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromForm] UpdateJobRequest request)
        {
            JobDto result = await _mediator.Send(new UpdateJobCommand()
            {
                Id = Id,
                JobTitle = request.JobTitle,
                DepartementId= request.DepartementId,
            });
            return Ok(new ApiResponse<JobDto>()
            {
                Code = 200,
                Success = true,
                Data = result,
                Message = "create with success",
                Meta = null
            });
        }
        [HttpGet]
        public async Task<IActionResult> Listes([FromQuery] GetAllJobsQuery query)
        {
            GetAllJobsQueryResponse result = await _mediator.Send(new GetAllJobsQuery()
            {
                Limit = query.Limit,
                Page = query.Page,
                Search = query.Search
            });
            return Ok(new ApiResponse<IEnumerable<JobDto>>()
            {
                Code = 200,
                Success = true,
                Data = result.Data ?? [],
                Message = "retrieved with success",
                Meta = new Meta
                {
                    Limit = query.Limit,
                    Page = query.Page,
                    TotalPage = result.TotalPage,
                    Total = result.Total
                }
            });
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> FindOne([FromQuery] GetOneJobQuery query)
        {
            JobDto result = await _mediator.Send(new GetOneJobQuery() { Id = query.Id });

            return Ok(new ApiResponse<JobDto>()
            {
                Code = 200,
                Success = true,
                Data = result,
                Message = "retrieved with success",
                Meta = null
            });
        }
    }
}