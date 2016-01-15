using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.Presentation.WUI.Models.User;
using WIPCream.BusinessGateway.Logic.Model;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class UserMapper
    {
        public static List<UserUIDTO> GetUserUIDTOList(List<UsersDTO> userList)
        {
            Mapper.CreateMap<List<UsersDTO>, List<UserUIDTO>>();
            List<UserUIDTO> userUIDTO = new List<UserUIDTO>();
            UserUIDTO model;
            foreach (var item in userList)
            {
                Mapper.CreateMap<UsersDTO, UserUIDTO>();
                model = Mapper.Map<UserUIDTO>(item);
                userUIDTO.Add(model);
            }
            return userUIDTO;
        }

        public static UsersDTO GetUserDTO(UserUIDTO user)
        {
            Mapper.CreateMap<UserUIDTO, UsersDTO>();
            return Mapper.Map<UsersDTO>(user);
        }
    }
}