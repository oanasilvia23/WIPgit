using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.Presentation.WUI.Models.UserDiscipline;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class UserDisciplineMapper
    {
        public static List<UserDisciplineUIDTO> GetUserDisciplineUIDTOList(List<UserDisciplineDTO> userDisciplineList)
        {
            Mapper.CreateMap<List<UserDisciplineDTO>, List<UserDisciplineUIDTO>>();
            List<UserDisciplineUIDTO> userDisciplineUIDTO = new List<UserDisciplineUIDTO>();
            UserDisciplineUIDTO model;
            foreach (var item in userDisciplineList)
            {
                Mapper.CreateMap<UserDisciplineDTO, UserDisciplineUIDTO>();
                model = Mapper.Map<UserDisciplineUIDTO>(item);
                userDisciplineUIDTO.Add(model);
            }
            return userDisciplineUIDTO;
        }

        public static UserDisciplineDTO GetUserDisciplineDTO(UserDisciplineUIDTO userDiscipline)
        {
            Mapper.CreateMap<UserDisciplineUIDTO, UserDisciplineDTO>();
            return Mapper.Map<UserDisciplineDTO>(userDiscipline);
        }
    }
}