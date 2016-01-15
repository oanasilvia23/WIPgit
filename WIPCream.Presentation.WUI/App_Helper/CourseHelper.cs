using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.Course;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Course;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class CourseHelper
    {
        private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);

        public CourseListUIDTO GetCourses(CourseUIDTO filter, int page)
        {
            ICourseBusinessService CourseService = new CourseBusinessService();
            var Courses = CourseService.RetrieveAll();
            var CoursesUi = CourseMapper.GetCourseUIDTOList(Courses);
            var model = new CourseListUIDTO();

            model.Courses = CoursesUi.ToPagedList(page, pageSize);
            model.Filter = new CourseUIDTO();
            return model;
        }
    }
}