using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.CourseEntity;

namespace WIPCream.BusinessGateway.Logic.Services.Course
{
    public class CourseBusinessService:ICourseBusinessService
    {
        private ICourseService courseService;
        private Courses courseModel;

        public CourseBusinessService()
        {
            courseService = new CourseService();
        }

        public WIPCream2 getDB()
        {
            return courseService.GetDB();
        }

        public string ResgisterCourse(CourseDTO model)
        {
            String transactionmessage = null;
            Transform_Courses_CoursesDTO(model);
            transactionmessage = courseService.CreateEntity(courseModel);
            return transactionmessage;
        }

        public string Delete(int id)
        {
            String transactionmessage = null;
            transactionmessage = courseService.DeleteEntity(id);
            return transactionmessage;
        }

        public string Update(CourseDTO test)
        {
            String transactionmessage = null;
            Transform_Courses_CoursesDTO(test);
            transactionmessage = courseService.UpdateEntity(courseModel);
            return transactionmessage;
        }

        public List<CourseDTO> RetrieveAll()
        {
            List<CourseDTO> CourseModel = new List<CourseDTO>();
            List<Courses> Courses = courseService.RetrieveAll();
            Mapper.CreateMap<Courses, CourseDTO>();
            CourseDTO model;
            for (int i = 0; i < Courses.Count(); i++)
            {
                model = Mapper.Map<CourseDTO>(Courses[i]);
                CourseModel.Add(model);
            }

            return CourseModel;
        }

        public CourseDTO FindById(int id)
        {
            CourseDTO model = new CourseDTO();
            courseModel = courseService.Find(id);

            Mapper.CreateMap<Courses, CourseDTO>();
            model = Mapper.Map<CourseDTO>(courseModel);
            return model;
        }

        public void Transform_Courses_CoursesDTO(CourseDTO model)
        {
            Mapper.CreateMap<CourseDTO, Courses>();
            courseModel = Mapper.Map<Courses>(model);
        }

        public void Dispose()
        {
            courseService.Dispose();
        }
    }
}
