using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalManager.Api.Model;
using PersonalManager.Application.Features.Children.Command.CreateChild;
using PersonalManager.Application.Features.Children.Command.DeleteChild;
using PersonalManager.Application.Features.Children.Command.UpdateChild;
using PersonalManager.Application.Features.Children.Query.GetAllChildren;

namespace PersonalManager.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ChildController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateChildRequest request)
        {
            CreateChildResponse result = await _mediator.Send(new CreateChildCommand()
            {
                EmployeeId = request.EmployeeId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Avatar = request.Avatar,
                BirthDate = request.BirthDate,
                BirthPlace = request.BirthPlace,
                CIN = request.CIN,
                Gender = request.Gender,
                IsDependent = request.IsDependent,
                Nationality = request.Nationality
            });
            return Ok(new ApiResponse<CreateChildResponse>
            {
                Code = 200,
                Data = result,
                Message = "create with success",
                Meta = null,
                Success = true
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            await _mediator.Send(new DeleteChildCommand()
            {
                Id = Id
            });
            return Ok(new ApiResponse<CreateChildResponse>
            {
                Code = 200,
                Data = null,
                Message = "delete with success",
                Meta = null,
                Success = true
            });
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id,[FromForm] UpdateChildRequest request)
        {
            UpdateChildResponse result = await _mediator.Send(new UpdateChildCommand()
            {
                Id = Id,
                BirthDate = request.BirthDate,
                BirthPlace = request.BirthPlace,
                FirstName = request.FirstName,
                IsDependent = request.IsDependent,
                Avatar = request.Avatar,
                Gender = request.Gender,
                LastName = request.LastName,
                Nationality = request.Nationality
            });

            return Ok(new ApiResponse<UpdateChildResponse>
            {
                Code = 200,
                Data = result,
                Message = "delete with success",
                Meta = null,
                Success = true
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllChildrenQuery request)
        {
            GetAllChildResponse result = await _mediator.Send(request);

            return Ok(new ApiResponse<IEnumerable<ChildrenResponse>>
            {
                Code = 200,
                Data = result.Data.ToList() ?? [],
                Message = "delete with success",
                Meta = new Meta()
                {
                    Limit = request.Limit,
                    Page = request.Page,
                    Total = result.Total,
                    TotalPage = result.TotalPage,
                },
                Success = true
            });

        }
    }
}
