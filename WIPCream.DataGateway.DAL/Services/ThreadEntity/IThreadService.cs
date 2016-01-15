using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.ThreadEntity
{
    public interface IThreadService
    {
        string CreateEntity(Threads model);
        Threads Find(int id);
        string DeleteEntity(int id);
        string UpdateEntity(Threads model);
        List<Threads> RetrieveAll();
        WIPCream2 GetDB();
        void Dispose();
    }
}
