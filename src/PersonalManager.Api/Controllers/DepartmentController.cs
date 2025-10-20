using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalManager.Api.Model;
using PersonalManager.Application.Dtos;
using PersonalManager.Application.Features.Departments.Command.CreateDepartment;
using PersonalManager.Application.Features.Departments.Command.DeleteDepartment;
using PersonalManager.Application.Features.Departments.Command.UpdateDepartment;
using PersonalManager.Application.Features.Departments.Query.GetAllDeprtaments;
using PersonalManager.Application.Features.Departments.Query.GetOneDepartment;
using PersonaManager.Domain.Entities;

namespace PersonalManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateDepartmentRequest request)
        {
            DepartmentDto result = await _mediator.Send(new CreateDepartmentCommand()
            {
                DepartmentName = request.DepartmentName
            });

            return Ok(new ApiResponse<DepartmentDto>()
            {
                Code = 200,
                Success = true,
                Data = result,
                Message = "create with success",
                Meta = null
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteDepartmentCommand request)
        {
            await _mediator.Send(new DeleteDepartmentCommand() { Id = request.Id });
            return Ok(new ApiResponse<DepartmentDto>
            {
                Code = 200,
                Success = true,
                Data = null,
                Message = "Delete with success",
                Meta = null
            });
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromForm] UpdateDepartmentRequest request)
        {
            var result = await _mediator.Send(new UpdateDepartmentCommand()
            {
                Id = Id,
                DepartmentName = request.DepartmentName
            });
            return Ok(new ApiResponse<DepartmentDto>()
            {
                Code = 200,
                Success = true,
                Data = result,
                Message = "create with success",
                Meta = null
            });
        }
        [HttpGet]
        public async Task<IActionResult> Listes([FromQuery] GetAllDepartmentQuery query)
        {
            var result = await _mediator.Send(new GetAllDepartmentQuery()
            {
                Limit = query.Limit,
                Page = query.Page,
                Search = query.Search
            });
            return Ok(new ApiResponse<IEnumerable<Department>>()
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
        public async Task<IActionResult> FindOne([FromQuery] GetOneDepartmentQuery query)
        {
            DepartmentDto result = await _mediator.Send(new GetOneDepartmentQuery() { Id = query.Id });
            
            return Ok(new ApiResponse<DepartmentDto>()
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