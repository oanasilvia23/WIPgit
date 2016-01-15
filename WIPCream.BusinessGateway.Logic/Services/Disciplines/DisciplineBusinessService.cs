using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.DisciplineEntity;

namespace WIPCream.BusinessGateway.Logic.Services.Disciplines
{
    public class DisciplineBusinessService:IDisciplineBusinessService
    {
        private IDisciplineService disciplineService;
        private DataGateway.DAL2.Models.Disciplines disciplineModel;

        public DisciplineBusinessService()
        {
            disciplineService = new DisciplineService();
        }

        public WIPCream2 getDB()
        {
            return disciplineService.GetDB();
        }

        public string ResgisterDiscipline(DisciplineDTO model)
        {
            String transactionmessage = null;
            Transform_Disciplines_DisciplinesDTO(model);
            transactionmessage = disciplineService.CreateEntity(disciplineModel);
            return transactionmessage;
        }

        public string Delete(int id)
        {
            String transactionmessage = null;
            transactionmessage = disciplineService.DeleteEntity(id);
            return transactionmessage;
        }

        public string Update(DisciplineDTO userDiscipline)
        {
            String transactionmessage = null;
            Transform_Disciplines_DisciplinesDTO(userDiscipline);
            transactionmessage = disciplineService.UpdateEntity(disciplineModel);
            return transactionmessage;
        }

        public List<DisciplineDTO> RetrieveAll()
        {
            List<DisciplineDTO> disciplineModel = new List<DisciplineDTO>();
            List<DataGateway.DAL2.Models.Disciplines> disciplines = disciplineService.RetrieveAll();
            Mapper.CreateMap<DataGateway.DAL2.Models.Disciplines, DisciplineDTO>();
            DisciplineDTO model;
            for (int i = 0; i < disciplines.Count(); i++)
            {
                model = Mapper.Map<DisciplineDTO>(disciplines[i]);
                disciplineModel.Add(model);
            }

            return disciplineModel;
        }

        public DisciplineDTO FindById(int id)
        {
            DisciplineDTO model = new DisciplineDTO();
            disciplineModel = disciplineService.Find(id);

            Mapper.CreateMap<DataGateway.DAL2.Models.Disciplines, DisciplineDTO>();
            model = Mapper.Map<DisciplineDTO>(disciplineModel);
            return model;
        }

        public void Transform_Disciplines_DisciplinesDTO(DisciplineDTO model)
        {
            Mapper.CreateMap<DisciplineDTO, DataGateway.DAL2.Models.Disciplines>();
            disciplineModel = Mapper.Map<DataGateway.DAL2.Models.Disciplines>(model);
        }

        public void Dispose()
        {
            disciplineService.Dispose();
        }
    }
}
