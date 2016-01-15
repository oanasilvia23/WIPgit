using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Services.Disciplines
{
    public interface IDisciplineBusinessService
    {
        string ResgisterDiscipline(DisciplineDTO model);
        string Delete(int id);
        List<DisciplineDTO> RetrieveAll();
        DisciplineDTO FindById(int id);
        string Update(DisciplineDTO discipline);
        WIPCream2 getDB();
        void Dispose();
    }
}
