using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class CourseListDTO
    {
        public CourseDTO Filter { get; set; }
        public List<CourseDTO> Courses { get; set; }
    }
}
