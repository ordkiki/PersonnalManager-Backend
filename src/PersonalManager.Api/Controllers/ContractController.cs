using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalManager.Api.Model;
using PersonalManager.Application.Dtos;

using PersonalManager.Application.Features.Contracts.Command.CreateContract;
using PersonalManager.Application.Features.Contracts.Command.DeleteContract;
using PersonalManager.Application.Features.Contracts.Command.UpdateContract;
using PersonalManager.Application.Features.Contracts.Query.GetAllContracts;
using PersonalManager.Application.Features.Contracts.Query.GetOneContract;

namespace PersonalManager.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContractController(IMediator _mediator) : ControllerBase
    {

        [HttpPost("{EmployeeId}")]
        public async Task<IActionResult> Create([FromRoute] Guid EmployeeId, [FromForm] CreateContractRequest request)
        {
            ContractDto result = await _mediator.Send(new CreateContractCommand()
            {
                TypeContrat = request.TypeContrat,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                SalaryMensual = request.SalaryMensual,
                EmployeeId = EmployeeId,
            });

            return Ok(new ApiResponse<ContractDto>()
            {
                Code = 200,
                Success = true,
                Data = result,
                Message = "create with success",
                Meta = null
            });
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            await _mediator.Send(new DeleteContractCommand() { Id = Id });
            return Ok(new ApiResponse<ContractDto>
            {
                Code = 200,
                Success = true,
                Data = null,
                Message = "Delete with success",
                Meta = null
            });
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromForm] UpdateContractRequest request)
        {
            ContractDto result = await _mediator.Send(new UpdateContractCommand()
            {
                Id = Id,
                EndDate = request.EndDate,
                StartDate = request.StartDate,
                IsActive = request.IsActive,
                SalaryMensual = request.SalaryMensual,
            });
            return Ok(new ApiResponse<ContractDto>()
            {
                Code = 200,
                Success = true,
                Data = result,
                Message = "create with success",
                Meta = null
            });
        }
        [HttpGet]
        public async Task<IActionResult> Listes([FromQuery] GetAllContractsQuery query)
        {
            GetAllContractsResponse result = await _mediator.Send(new GetAllContractsQuery()
            {
                Limit = query.Limit,
                Page = query.Page,
                Search = query.Search
            });
            return Ok(new ApiResponse<IEnumerable<ContractDto>>()
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
        [HttpGet("ById")]
        public async Task<IActionResult> FindOne([FromQuery] Guid Id)
        {
            ContractDto result = await _mediator.Send(new GetOneContractQuery() { Id = Id });

            return Ok(new ApiResponse<ContractDto>()
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
