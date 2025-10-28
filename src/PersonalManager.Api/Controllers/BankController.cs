using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalManager.Api.Model;
using PersonalManager.Application.Dtos;
using PersonalManager.Application.Features.Banks.Command.CreateBank;
using PersonalManager.Application.Features.Banks.Command.DeleteBank;
using PersonalManager.Application.Features.Banks.Command.UpdateBank;
using PersonalManager.Application.Features.Banks.Query.GetAllBanks;
using PersonalManager.Application.Features.Banks.Query.GetBankBy;

using PersonaManager.Domain.Entities;

namespace PersonalManager.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BankController(IMediator _mediator) : ControllerBase
    {

        [HttpPost("{EmployeeId}")]
        public async Task<IActionResult> Create([FromRoute] Guid EmployeeId, [FromForm] CreateBankRequest request)
        {
            BankDto result = await _mediator.Send(new CreateBankCommand()
            {
                AccountLabel = request.AccountLabel,
                Bic = request.Bic,
                CountryCode = request.CountryCode,
                EmployeeId = EmployeeId,
                Iban = request.Iban,
                Rib = request.Rib
            });

            return Ok(new ApiResponse<BankDto>()
            {
                Code = 200,
                Success = true,
                Data = result,
                Message = "create with success",
                Meta = null
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteBankCommand request)
        {
            await _mediator.Send(new DeleteBankCommand() { Id = request.Id });
            return Ok(new ApiResponse<BankDto>
            {
                Code = 200,
                Success = true,
                Data = null,
                Message = "Delete with success",
                Meta = null
            });
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromForm] UpdateBankRequest request)
        {
            BankDto result = await _mediator.Send(new UpdateBankCommand()
            {
                Id = Id,
                AccountLabel = request.AccountLabel,
                Bic = request.Bic,
                CountryCode = request.CountryCode,
                Iban = request.Iban,
                Rib = request.Rib
            });
            return Ok(new ApiResponse<BankDto>()
            {
                Code = 200,
                Success = true,
                Data = result,
                Message = "create with success",
                Meta = null
            });
        }
        [HttpGet]
        public async Task<IActionResult> Listes([FromQuery] GetAllBanksQuery query)
        {
            GetAllBanksResponse result = await _mediator.Send(new GetAllBanksQuery()
            {
                Limit = query.Limit,
                Page = query.Page,
                Search = query.Search
            });
            return Ok(new ApiResponse<IEnumerable<BankDto>>()
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
            BankDto result = await _mediator.Send(new GetBankByIdQuery() { Id = Id });

            return Ok(new ApiResponse<BankDto>()
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
