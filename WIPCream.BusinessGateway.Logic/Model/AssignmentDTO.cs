using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class AssignmentDTO
    {
        public int AssignmentId { get; set; }
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> Deadline { get; set; }

        public virtual Disciplines Discipline { get; set; }

        public string Image { get; set; }
    }
}
