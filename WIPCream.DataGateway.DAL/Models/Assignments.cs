using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.DataGateway.DAL2.Models
{
    public partial class Assignments
    {
        [Key]
        public int AssignmentId { get; set; }
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> Deadline { get; set; }

        public virtual Disciplines Disciplines { get; set; }

        public string Image { get; set; }
    }
}
