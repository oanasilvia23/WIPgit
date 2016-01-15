using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Services.Assignments
{
    public interface IAssignmentBusinessSerevice
    {
        string ResgisterAssignment(AssignmentDTO model);
        string Delete(int id);
        List<AssignmentDTO> RetrieveAll();
        AssignmentDTO FindById(int id);
        string Update(AssignmentDTO discipline);
        WIPCream2 getDB();
        void Dispose();
    }
}
