using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.DataGateway.DAL2.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }

        public virtual Disciplines Discipline { get; set; }

        public string Image { get; set; }
    }
}
