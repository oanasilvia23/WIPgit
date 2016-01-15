using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.PostEntity
{
    public interface IPostService
    {
        string CreateEntity(Posts model);
        Posts Find(int id);
        string DeleteEntity(int id);
        string UpdateEntity(Posts model);
        List<Posts> RetrieveAll();
        List<Posts> getByThreadId(int id);
        WIPCream2 GetDB();
        void Dispose();
    }
}
