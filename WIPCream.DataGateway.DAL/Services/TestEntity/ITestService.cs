using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.TestEntity
{
    public interface ITestService
    {
        string CreateEntity(Tests model);
        Tests Find(int id);
        string DeleteEntity(int id);
        string UpdateEntity(Tests model);
        List<Tests> RetrieveAll();
        WIPCream2 GetDB();
        void Dispose();
    }
}
