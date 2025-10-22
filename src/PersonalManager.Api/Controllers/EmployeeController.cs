using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalManager.Api.Model;
using PersonalManager.Application.Features.Employees.Command.CreateEmployeeAdress;
using PersonalManager.Application.Features.Employees.Command.CreateEmployeeBadge;
using PersonalManager.Application.Features.Employees.Command.CreateEmployeeIdentity;
using PersonalManager.Application.Features.Employees.Command.DeleteEmployee;
using PersonalManager.Application.Features.Employees.Command.UpdateEmployeeAvatar;
using PersonalManager.Application.Features.Employees.Command.UpdateEmployeeStatus;
using PersonalManager.Application.Features.Employees.Query.GetAllEmployees;
using PersonalManager.Application.Features.Employees.Query.GetOneEmployees;
using PersonaManager.Domain.Entities;

namespace PersonalManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBadge(CreateEmployeeBadgeRequest request)
        {
            CreateEmployeeBadgeResponse result = await _mediator.Send(new CreateEmployeeBadgeCommand
            {
                Civility = request.Civility,
                Email = request.Email,
                FirstName = request.FirstName,
                JobId = request.JobId,
                LastName = request.LastName,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
                Avatar = request.Avatar,
            });
            return Ok(new ApiResponse<CreateEmployeeBadgeResponse>
            {
                Code = 200,
                Data = result,
                Message = "create with success",
                Meta = null,
                Success = true
            });
        }

        [HttpPut("Identity")]
        public async Task<IActionResult> UpdateIdentity([FromRoute] Guid Id, [FromForm] CreateEmployeeIdentityRequest request)
        {
            CreateEmployeeIdentityResponse result = await _mediator.Send(new CreateEmployeeIdentityCommand
            {
                EmployeeId = Id,
                FirstName = request?.FirstName,
                LastName = request?.LastName,
                Gender = request?.Gender,
                BirthPlace = request.BirthPlace,
                BirthDate = request.BirthDate,
                Nationality = request?.Nationality,
                CIN = request.CIN,
                Image = request?.Image,

            });
            return Ok(new ApiResponse<CreateEmployeeIdentityResponse>
            {
                Code = 200,
                Data = result,
                Message = "create with success",
                Meta = null,
                Success = true
            });
        }

        [HttpPut("Adress")]
        public async Task<IActionResult> UpdateAdress([FromRoute] Guid Id, [FromForm] CreateEmployeeAdressCommand request)
        {
            CreateEmployeeAdressResponse result = await _mediator.Send(new CreateEmployeeAdressCommand
            {
                EmployeeId = Id,
                Area = request?.Area,
                City = request?.City,
                Country = request?.Country,
                District = request?.District,
                PostalCode = request?.PostalCode,
                Street = request?.Street,
                Region = request?.Region,
            });
            return Ok(new ApiResponse<CreateEmployeeAdressResponse>
            {
                Code = 200,
                Data = result,
                Message = "create with success",
                Meta = null,
                Success = true
            });
        }

        [HttpDelete]
        public async Task<IActionResult> UpdateAdress([FromQuery] Guid EmployeeId)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand() { Id = EmployeeId });

            return Ok(new ApiResponse<CreateEmployeeAdressResponse>
            {
                Code = 200,
                Data = null,
                Message = "Delete with success",
                Meta = null,
                Success = true
            });
        }

        [HttpPut("Status")]
        public async Task<IActionResult> UpdateStatus([FromRoute] Guid EmployeeId, [FromBody] UpdateEmployeeStatusCommand request)
        {
            var result = await _mediator.Send(new UpdateEmployeeStatusCommand()
            {
                EmployeeId = EmployeeId, Status = request.Status
            });

            return Ok(new ApiResponse<UpdateEmployeeStatusResponse>
            {
                Code = 200,
                Data = result,
                Message = "Delete with success",
                Meta = null,
                Success = true
            });
        }
        [HttpPut("Avatar")]
        public async Task<IActionResult> UpdateAvatar([FromRoute] Guid EmployeeId, [FromForm] UpdateEmployeeAvatarRequest request)
        {
            UpdateEmployeeAvatarResponse result = await _mediator.Send(new UpdateEmployeeAvatarCommand()
            {
                EmployeeId = EmployeeId,
                Avatar = request.Avatar,
            });

            return Ok(new ApiResponse<UpdateEmployeeAvatarResponse>
            {
                Code = 200,
                Data = result,
                Message = "Delete with success",
                Meta = null,
                Success = true
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllEmployeeQuery request)
        {
            GetAllEmployeeQueryResponse result = await _mediator.Send(request);


            return Ok(new ApiResponse<IEnumerable<Employee>>
            {
                Code = 200,
                Success = true,
                Data = result.Data,
                Message = "Delete with success",
                Meta = new Meta()
                {
                    Limit = request.Limit,
                    Page = request.Page,
                    Total = result.Total,
                    TotalPage = result.TotalPage,
                },
            });
        }

        [HttpGet("{Term}")]
        public async Task<IActionResult> GetBy([FromRoute] GetOneEmployeeQuery request)
        {
            GetOneEmployeeResponse result = await _mediator.Send(request);


            return Ok(new ApiResponse<GetOneEmployeeResponse>
            {
                Code = 200,
                Success = true,
                Data = result,
                Message = "Delete with success",
                Meta = null
            });
        }
    }
}