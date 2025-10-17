using MediatR;
using PersonalManager.Application.Features.Educations.Command.UpdateEmployeeEducation;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Educations.Command.UpdateEducation
{
    public class UpdateEducationCommandHandler(IRepositoryCommand<Education> _repo) : IRequestHandler<UpdateEducationCommand, UpdateEducationResponse>
    {
        public async Task<UpdateEducationResponse> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            Education education = await _repo.UpdateAsync(request.Id, new Education
            {
                Graduation = request.Graduation,
                FieldOfStudy = request.FieldOfStudy,
                Establishment = request.Establishment,
                GraduationYear = request.GraduationYear,
            }, cancellationToken);
            return new UpdateEducationResponse
            {
                Id = request.Id,
                Education = new ()
                {
                    Graduation = request.Graduation,
                    FieldOfStudy = request.FieldOfStudy,
                    Establishment = request.Establishment,
                    GraduationYear = request.GraduationYear,
                }

            };
        }
    }
}