using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.DataGateway.DAL2.Models
{
    public class UserDisciplines
    {
        [Key]
        public int UserDisciplineId { get; set; }
        public int UsereId { get; set; }
        public int DisciplineId { get; set; }

        public virtual Disciplines Discipline { get; set; }
        public virtual Users Users { get; set; }
    }
}
