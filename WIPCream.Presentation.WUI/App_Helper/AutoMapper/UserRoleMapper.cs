using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.Presentation.WUI.Models.UserRole;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class UserRoleMapper
    {
        public static List<UserRoleUIDTO> GetUserRoleUIDTOList(List<UserRoleDTO> userRoleList)
        {
            Mapper.CreateMap<List<UserRoleDTO>, List<UserRoleUIDTO>>();
            List<UserRoleUIDTO> roleUIDTO = new List<UserRoleUIDTO>();
            UserRoleUIDTO model;
            foreach (var item in userRoleList)
            {
                Mapper.CreateMap<UserRoleDTO, UserRoleUIDTO>();
                model = Mapper.Map<UserRoleUIDTO>(item);
                roleUIDTO.Add(model);
            }
            return roleUIDTO;
        }

        public static UserRoleDTO GetUserRoleDTO(UserRoleUIDTO role)
        {
            Mapper.CreateMap<UserRoleUIDTO, UserRoleDTO>();
            return Mapper.Map<UserRoleDTO>(role);
        }

        public static UserRoleUIDTO GetUserRoleUIDTO(UserRoleDTO model)
        {
            Mapper.CreateMap<UserRoleDTO, UserRoleUIDTO>();
            return Mapper.Map<UserRoleUIDTO>(model);
        }
    }
}