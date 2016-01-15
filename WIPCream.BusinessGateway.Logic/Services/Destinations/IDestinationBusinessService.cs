using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Services.Destinations
{
    public interface IDestinationBusinessService
    {
        string ResgisterDestination(destinationDTO model);
        string Delete(int id);
        List<destinationDTO> RetrieveAll();
        destinationDTO FindById(int id);
        string Update(destinationDTO destination);
        WIPCream2 getDB();
        void Dispose();
    }
}
