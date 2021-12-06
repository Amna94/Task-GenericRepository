using Amy_WebApplication.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amy_WebApplication.Interfejsi
{
    public interface IRepositoryRolePermission : IRepositoryGeneric<RolePermission>
    {
        void Create(string roleId, string permissionId);
        void Remove(string roleId, string permissionId);
        Task FindAll(string roleId);
        Task FindBy(string id);
    }
}
