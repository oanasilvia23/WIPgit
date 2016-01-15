using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.UserDisciplineEntity
{
    public interface IUserDisciplinesService
    {
        string CreateEntity(UserDisciplines model);
        UserDisciplines Find(int id);
        string DeleteEntity(int id);
        string UpdateEntity(UserDisciplines model);
        List<UserDisciplines> RetrieveAll();
        WIPCream2 GetDB();
        void Dispose();
    }
}
