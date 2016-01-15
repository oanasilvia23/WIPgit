using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.UsersEntity
{
    public interface IUsersService
    {
        string CreateEntity(Users model);
        Users Find(int id);
        Users FindByEmail(string email);
        string DeleteEntity(int id);
        string UpdateEntity(Users model);
        List<Users> RetrieveAll();
        void Dispose();
    }
}
