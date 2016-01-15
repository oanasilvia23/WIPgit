using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Services.UserDisciplines
{
    public interface IUserDisciplineBusinessService
    {
        string ResgisterUserDiscipline(UserDisciplineDTO model);
        string Delete(int id);
        List<UserDisciplineDTO> RetrieveAll();
        UserDisciplineDTO FindById(int id);
        string Update(UserDisciplineDTO userDiscipline);
        WIPCream2 getDB();
        void Dispose();
    }
}
