using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Interfaces.Services
{
    public interface IHierarchyService
    {
        Task<bool> Verify(Guid? parentId, Guid? currentId = null);
        Task<bool> IsExistDepartment(Guid parentId);
    }
}