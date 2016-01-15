using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Services.Test
{
    public interface ITestBusinessService
    {
        string ResgisterTest(TestDTO model);
        string Delete(int id);
        List<TestDTO> RetrieveAll();
        TestDTO FindById(int id);
        string Update(TestDTO Test);
        WIPCream2 getDB();
        void Dispose();
    }
}
