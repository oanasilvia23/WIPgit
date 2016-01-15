using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class UserDisciplineDTO
    {
        public int UserDisciplineId { get; set; }
        public int UsereId { get; set; }
        public int DisciplineId { get; set; }

        public virtual Disciplines Discipline { get; set; }
        public virtual Users Users { get; set; }
    }
}
