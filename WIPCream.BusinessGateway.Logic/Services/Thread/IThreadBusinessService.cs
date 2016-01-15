using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Services.Thread
{
    public interface IThreadBusinessService
    {
        string ResgisterThread(ThreadDTO model);
        string Delete(int id);
        List<ThreadDTO> RetrieveAll();
        ThreadDTO FindById(int id);
        string Update(ThreadDTO Thread);
        WIPCream2 getDB();
        void Dispose();
    }
}
