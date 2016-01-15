using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.UserRoleEntity
{
    public interface IUserRoleService
    {
        string CreateEntity(UserRoles model);
        UserRoles Find(int id);
        string DeleteEntity(int id);
        WIPCream2 getDB();
        string UpdateEntity(UserRoles model);
        List<Users> RetrieveUnassigned();
        List<UserRoles> RetrieveAll();
        List<UserRoles> FindByUserId(int id);
        void Dispose();
    }
}
