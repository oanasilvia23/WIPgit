using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Services.UserRoles
{
    public interface IUserRoleBusinessService
    {
        string ResgisterRole(UserRoleDTO model);
        string Delete(int id);
        List<Users> RetrieveUnassigned();
        List<UserRoleDTO> RetrieveAll();
        UserRoleDTO FindById(int id);
        string Update(UserRoleDTO user);
        WIPCream2 getDB();
        List<UserRoleDTO> FindRolesbyUserID(int id);
        void Dispose();
    }
}
