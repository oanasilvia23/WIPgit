using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.Presentation.WUI.Models.Course;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class CourseMapper
    {
        public static List<CourseUIDTO> GetCourseUIDTOList(List<CourseDTO> CourseList)
        {
            Mapper.CreateMap<List<CourseDTO>, List<CourseUIDTO>>();
            List<CourseUIDTO> CourseUIDTO = new List<CourseUIDTO>();
            CourseUIDTO model;
            foreach (var item in CourseList)
            {
                Mapper.CreateMap<CourseDTO, CourseUIDTO>();
                model = Mapper.Map<CourseUIDTO>(item);
                CourseUIDTO.Add(model);
            }
            return CourseUIDTO;
        }

        public static CourseDTO GetCourseDTO(CourseUIDTO Course)
        {
            Mapper.CreateMap<CourseUIDTO, CourseDTO>();
            return Mapper.Map<CourseDTO>(Course);
        }

        public static CourseUIDTO GetCourseUIDTO(CourseDTO Course)
        {
            Mapper.CreateMap<CourseDTO, CourseUIDTO>();
            return Mapper.Map<CourseUIDTO>(Course);
        }
    }
}