using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.UpdateEmployeeAvatar
{
    public class UpdateEmployeeAvatarCommandHandler(IFileService _fileService, IRepositoryCommand<Employee> _repo, IRepositoryQuery<Employee> _repo2,IUnitOfWork _unit) : IRequestHandler<UpdateEmployeeAvatarCommand, UpdateEmployeeAvatarResponse>
    {
        public async Task<UpdateEmployeeAvatarResponse> Handle(UpdateEmployeeAvatarCommand request, CancellationToken cancellationToken)
        {
            Employee? emp = await _repo2.FindByIdAsync(request.EmployeeId, cancellationToken) ?? throw new ApiException("no employee found", 400, false);

            emp.Identity!.Avatar = await _fileService.UploadAsync(request.Avatar, Folder.EMPLOYEES.ToString());

   
            await _unit.SaveChangesAsync(cancellationToken);

            return new UpdateEmployeeAvatarResponse
            {
                EmployeeId = emp.Id,
                Avatar = emp.Identity.Avatar,
            };
        }
    }
}
