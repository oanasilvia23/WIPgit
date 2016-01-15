using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.UserRoleEntity;

namespace WIPCream.BusinessGateway.Logic.Services.UserRoles
{
    public class UserRoleBusinessService:IUserRoleBusinessService
    {
        private IUserRoleService userRoleService;
        private DataGateway.DAL2.Models.UserRoles userRoleModel;

        public UserRoleBusinessService()
        {
            userRoleService = new UserRoleService();
        }

        public string ResgisterRole(UserRoleDTO model)
        {
            String transactionmessage = null;
            Transform_UserRole_UserRoleDTO(model);
            transactionmessage = userRoleService.CreateEntity(userRoleModel);
            return transactionmessage;
        }

        public WIPCream2 getDB()
        {
            return userRoleService.getDB();
        }

        public string Delete(int id)
        {
            String transactionmessage = null;
            transactionmessage = userRoleService.DeleteEntity(id);
            return transactionmessage;
        }

        public string Update(UserRoleDTO user)
        {
            String transactionmessage = null;
            Transform_UserRole_UserRoleDTO(user);
            transactionmessage = userRoleService.UpdateEntity(userRoleModel);
            return transactionmessage;
        }

        public List<Users> RetrieveUnassigned()
        {
            List<Users> roles = userRoleService.RetrieveUnassigned();

            return roles;
        }

        public List<UserRoleDTO> RetrieveAll()
        {
            List<UserRoleDTO> userRoleModel = new List<UserRoleDTO>();
            List<DataGateway.DAL2.Models.UserRoles> roles = userRoleService.RetrieveAll();
            Mapper.CreateMap<DataGateway.DAL2.Models.UserRoles, UserRoleDTO>();
            UserRoleDTO model;
            for (int i = 0; i < roles.Count(); i++)
            {
                model = Mapper.Map<UserRoleDTO>(roles[i]);
                userRoleModel.Add(model);
            }

            return userRoleModel;
        }

        public UserRoleDTO FindById(int id)
        {
            UserRoleDTO model = new UserRoleDTO();
            userRoleModel = userRoleService.Find(id);

            Mapper.CreateMap<DataGateway.DAL2.Models.UserRoles, UserRoleDTO>();
            model = Mapper.Map<UserRoleDTO>(userRoleModel);
            return model;
        }

        public List<UserRoleDTO> FindRolesbyUserID(int id)
        {
            List<UserRoleDTO> listDTO = null;
            List<DataGateway.DAL2.Models.UserRoles> list = userRoleService.FindByUserId(id);
            for (int i = 0; i < list.Count; i++)
            {

                Mapper.CreateMap<DataGateway.DAL2.Models.UserRoles, UserRoleDTO>();
                listDTO.Add(Mapper.Map<UserRoleDTO>(list[i]));
            }
            
            return listDTO;
        }

        public void Transform_UserRole_UserRoleDTO(UserRoleDTO model)
        {
            Mapper.CreateMap<UserRoleDTO, DataGateway.DAL2.Models.UserRoles>();
            userRoleModel = Mapper.Map<DataGateway.DAL2.Models.UserRoles>(model);
        }

        public void Dispose()
        {
            userRoleService.Dispose();
        }
    }
}
