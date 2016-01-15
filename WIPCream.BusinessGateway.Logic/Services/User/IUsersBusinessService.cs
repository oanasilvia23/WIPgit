using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;

namespace WIPCream.BusinessGateway.Logic.Services.User
{
    public interface IUsersBusinessService
    {
        string ResgisterUser(UsersDTO model);
        string Delete(int id);
        List<UsersDTO> RetrieveAll();
        UsersDTO FindById(int id);
        string Update(UsersDTO user);
        UsersDTO FindByEmail(string email);
        void Dispose();
    }
}
