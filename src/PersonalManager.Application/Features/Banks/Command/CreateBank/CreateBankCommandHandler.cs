using MediatR;
using PersonalManager.Application.Dtos;
using PersonalManager.Application.Mappers;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Command.CreateBank
{
    public class CreateBankCommandHandler(IRepositoryCommand<Bank> _repo, IRepositoryQuery<Employee> _repo2, IRepositoryQuery<Bank> _repo3, IUnitOfWork _unit) : IRequestHandler<CreateBankCommand, BankDto>
    {
        public async Task<BankDto> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {

            Employee? e = await _repo2.FindByIdAsync(request.EmployeeId, cancellationToken) ?? throw new ArgumentNullException("no employee found");

            Bank? b = await _repo3.GetByAsync(x => x.Iban == request.Iban, null, null);
            if (b is not null)
            {
                throw new ArgumentException("Bank with this IBAN already exists");
            };

            Bank bank = new ()
            {
                Rib = request.Rib!,
                Iban = request.Iban!,
                CountryCode = request.CountryCode,
                Bic = request.Bic,
                AccountLabel = request.AccountLabel,
                EmployeeId = request.EmployeeId
            };

            Bank result = await _repo.CreateAsync(bank, cancellationToken);
            await _unit.SaveChangesAsync(cancellationToken);
            return result.ToDto();
        }
    }
}
