using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class AssignmentListDTO
    {
        public AssignmentDTO Filter { get; set; }
        public List<AssignmentDTO> Assignments { get; set; }
    }
}
