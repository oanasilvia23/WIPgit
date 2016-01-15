using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.Course
{
    public class CourseListUIDTO
    {
        public CourseUIDTO Filter { get; set; }
        public IPagedList<CourseUIDTO> Courses { get; set; }
    }
}