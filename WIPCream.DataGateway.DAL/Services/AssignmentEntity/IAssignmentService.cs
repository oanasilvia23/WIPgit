using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.AssignmentEntity
{
    public interface IAssignmentService
    {
        string CreateEntity(Assignments model);
        Assignments Find(int id);
        string DeleteEntity(int id);
        string UpdateEntity(Assignments model);
        List<Assignments> RetrieveAll();
        WIPCream2 GetDB();
        void Dispose();
    }
}
