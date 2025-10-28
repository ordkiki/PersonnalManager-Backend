using FluentValidation;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Contracts.Command.CreateContract
{
    public class CreateContractValidation : AbstractValidator<CreateContractCommand>
    {
        public CreateContractValidation()
        {
            RuleFor(x => x.TypeContrat)
                .IsInEnum()
                .WithMessage("Type de contrat invalide")
                .WithErrorCode(ErrCode.NOT_IN_ENUM.ToString());

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .LessThan(DateTime.UtcNow.AddYears(10))
                .WithMessage("La date de début est invalide");

            //RuleFor(x => x.SalaryMensual)
            //    .GreaterThan(0)
            //    .When(x => x.SalaryMensual.HasValue)
            //    .WithMessage("Le salaire doit être positif");

            RuleFor(x => x.EndDate)
                .Must((contract, endDate) =>
                    !endDate.HasValue || endDate.Value > contract.StartDate)
                .WithMessage("La date de fin doit être supérieure à la date de début");

            When(x => x.TypeContrat == TypeContrat.CDI, () =>
            {
                RuleFor(x => x.EndDate)
                    .Must(end => end == null)
                    .WithMessage("CDI contract must not have a End date value");
            });

            When(x => new[] { TypeContrat.PARTTIME }.Contains(x.TypeContrat), () =>
            {
                RuleFor(x => x.SalaryMensual)
                    .NotNull()
                    .GreaterThan(0)
                    .WithMessage("Le salaire est obligatoire pour un contrat PartTime");
            });

            When(x => new[] { TypeContrat.STAGE, TypeContrat.INTERNSHIP, TypeContrat.INTERNATIONNALVOLUNTEER }.Contains(x.TypeContrat), () =>
            {
                RuleFor(x => x.EndDate)
                    .NotEmpty()
                    .WithMessage("Un stage / volontariat doit avoir une date de fin");
            });

            When(x => new[] { TypeContrat.CDD, TypeContrat.INTERIM, TypeContrat.SEASONAL, TypeContrat.CONSULTANT }.Contains(x.TypeContrat), () =>
            {
                RuleFor(x => x.EndDate)
                    .NotEmpty()
                    .WithMessage("Ce type de contrat doit avoir une date de fin");

                RuleFor(x => x.SalaryMensual)
                    .NotEmpty()
                    .GreaterThan(0)
                    .WithMessage("Le salaire est obligatoire pour ce type de contrat");
            });

            RuleFor(x => x.EmployeeId)
                .NotEmpty()
                .WithMessage("An salaried must associed with an employee");

            RuleFor(x => x.IsActive == true)
                .NotNull()
                .WithMessage("L’état du contrat est obligatoire");
        }
    }
}
