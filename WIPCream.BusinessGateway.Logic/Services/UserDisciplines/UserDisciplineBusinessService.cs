using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.UserDisciplineEntity;

namespace WIPCream.BusinessGateway.Logic.Services.UserDisciplines
{
    public class UserDisciplineBusinessService:IUserDisciplineBusinessService
    {
        private IUserDisciplinesService userService;
        private DataGateway.DAL2.Models.UserDisciplines userModel;

        public UserDisciplineBusinessService()
        {
            userService = new UserDisciplinesService();
        }

        public WIPCream2 getDB()
        {
            return userService.GetDB();
        }

        public string ResgisterUserDiscipline(UserDisciplineDTO model)
        {
            String transactionmessage = null;
            Transform_UserDisciplines_UserDisciplinesDTO(model);
            transactionmessage = userService.CreateEntity(userModel);
            return transactionmessage;
        }

        public string Delete(int id)
        {
            String transactionmessage = null;
            transactionmessage = userService.DeleteEntity(id);
            return transactionmessage;
        }

        public string Update(UserDisciplineDTO userDiscipline)
        {
            String transactionmessage = null;
            Transform_UserDisciplines_UserDisciplinesDTO(userDiscipline);
            transactionmessage = userService.UpdateEntity(userModel);
            return transactionmessage;
        }

        public List<UserDisciplineDTO> RetrieveAll()
        {
            List<UserDisciplineDTO> userModel = new List<UserDisciplineDTO>();
            List<DataGateway.DAL2.Models.UserDisciplines> users = userService.RetrieveAll();
            Mapper.CreateMap<DataGateway.DAL2.Models.UserDisciplines, UserDisciplineDTO>();
            UserDisciplineDTO model;
            for (int i = 0; i < users.Count(); i++)
            {
                model = Mapper.Map<UserDisciplineDTO>(users[i]);
                userModel.Add(model);
            }

            return userModel;
        }

        public UserDisciplineDTO FindById(int id)
        {
            UserDisciplineDTO model = new UserDisciplineDTO();
            userModel = userService.Find(id);

            Mapper.CreateMap<DataGateway.DAL2.Models.UserDisciplines, UserDisciplineDTO>();
            model = Mapper.Map<UserDisciplineDTO>(userModel);
            return model;
        }

        public void Transform_UserDisciplines_UserDisciplinesDTO(UserDisciplineDTO model)
        {
            Mapper.CreateMap<UserDisciplineDTO, DataGateway.DAL2.Models.UserDisciplines>();
            userModel = Mapper.Map<DataGateway.DAL2.Models.UserDisciplines>(model);
        }

        public void Dispose()
        {
            userService.Dispose();
        }
    }
}
