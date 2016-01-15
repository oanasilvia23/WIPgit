using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.UsersEntity;

namespace WIPCream.BusinessGateway.Logic.Services.User
{
    public class UserBusinessService : IUsersBusinessService
    {
        private IUsersService userService;
        private Users userModel;

        public UserBusinessService()
        {
            userService = new UsersService();
        }

        public string ResgisterUser(UsersDTO model)
        {
            String transactionmessage = null;
            Transform_Users_UsersDTO(model);
            transactionmessage = userService.CreateEntity(userModel);
            return transactionmessage;
        }

        public string Delete(int id)
        {
            String transactionmessage = null;
            transactionmessage = userService.DeleteEntity(id);
            return transactionmessage;
        }

        public string Update(UsersDTO user)
        {
            String transactionmessage = null;
            Transform_Users_UsersDTO(user);
            transactionmessage = userService.UpdateEntity(userModel);
            return transactionmessage;
        }

        public List<UsersDTO> RetrieveAll()
        {
            List<UsersDTO> userModel = new List<UsersDTO>();
            List<Users> users = userService.RetrieveAll();
            Mapper.CreateMap<Users, UsersDTO>();
            UsersDTO model;
            for (int i = 0; i < users.Count(); i++)
            {
                model = Mapper.Map<UsersDTO>(users[i]);
                userModel.Add(model);
            }

            return userModel;
        }

        public UsersDTO FindById(int id)
        {
            UsersDTO model = new UsersDTO();
            userModel = userService.Find(id);

            Mapper.CreateMap<Users, UsersDTO>();
            model = Mapper.Map<UsersDTO>(userModel);
            return model;
        }

        public UsersDTO FindByEmail(string email)
        {
            UsersDTO model = new UsersDTO();
            userModel = userService.FindByEmail(email);

            Mapper.CreateMap<Users, UsersDTO>();
            model = Mapper.Map<UsersDTO>(userModel);
            return model;
        }

        public void Transform_Users_UsersDTO(UsersDTO model)
        {
            Mapper.CreateMap<UsersDTO, Users>();
            userModel = Mapper.Map<Users>(model);
        }

        public void Dispose()
        {
            userService.Dispose();
        }
    }
}
