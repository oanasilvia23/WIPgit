using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.DestinationEntity
{
    public interface IDestinationService
    {
        string CreateEntity(destination model);
        destination Find(int id);
        string DeleteEntity(int id);
        string UpdateEntity(destination model);
        List<destination> RetrieveAll();
        WIPCream2 GetDB();
        void Dispose();
    }
}
