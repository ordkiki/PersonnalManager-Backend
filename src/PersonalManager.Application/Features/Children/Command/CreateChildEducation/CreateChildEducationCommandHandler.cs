using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;

namespace PersonalManager.Application.Features.Children.Command.CreateChildEducation
{
    public class CreateChildEducationCommandHandler(IRepositoryCommand<Education> _EducationRepo, IRepositoryQuery<Child> _repo2, IUnitOfWork _unit) : IRequestHandler<CreateChildEducationCommand, CreateChildEducationResponse>
    {
        public async Task<CreateChildEducationResponse> Handle(CreateChildEducationCommand request, CancellationToken cancellationToken)
        {
            Education education = new()
            {
                Graduation = request.Graduation,
                IdChild = request.ChildId,
                FieldOfStudy = request.FieldOfStudy,
                Establishment = request.Establishment,
                GraduationYear = request.GraduationYear,
                UpdatedAt = DateTime.UtcNow,
            };
            await _EducationRepo.CreateAsync(education, cancellationToken);
            await _unit.SaveChangesAsync(cancellationToken);

            return new CreateChildEducationResponse
            {
                Id = education.Id,
                Education = new ChildEdcation
                {
                    Establishment = education.Establishment,
                    FieldOfStudy = education.FieldOfStudy,
                    Graduation = education.Graduation,
                    GraduationYear = education.GraduationYear,
                }
            };
        }
    }
}