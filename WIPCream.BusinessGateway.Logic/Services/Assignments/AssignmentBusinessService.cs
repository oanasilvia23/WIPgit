using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.AssignmentEntity;

namespace WIPCream.BusinessGateway.Logic.Services.Assignments
{
    public class AssignmentBusinessService:IAssignmentBusinessSerevice
    {
        private IAssignmentService AssignmentService;
        private DataGateway.DAL2.Models.Assignments AssignmentModel;

        public AssignmentBusinessService()
        {
            AssignmentService = new AssignmentService();
        }

        public WIPCream2 getDB()
        {
            return AssignmentService.GetDB();
        }

        public string ResgisterAssignment(AssignmentDTO model)
        {
            String transactionmessage = null;
            Transform_Assignments_AssignmentsDTO(model);
            transactionmessage = AssignmentService.CreateEntity(AssignmentModel);
            return transactionmessage;
        }

        public string Delete(int id)
        {
            String transactionmessage = null;
            transactionmessage = AssignmentService.DeleteEntity(id);
            return transactionmessage;
        }

        public string Update(AssignmentDTO userAssignment)
        {
            String transactionmessage = null;
            Transform_Assignments_AssignmentsDTO(userAssignment);
            transactionmessage = AssignmentService.UpdateEntity(AssignmentModel);
            return transactionmessage;
        }

        public List<AssignmentDTO> RetrieveAll()
        {
            List<AssignmentDTO> AssignmentModel = new List<AssignmentDTO>();
            List<DataGateway.DAL2.Models.Assignments> Assign = AssignmentService.RetrieveAll();
            Mapper.CreateMap<DataGateway.DAL2.Models.Assignments, AssignmentDTO>();
            AssignmentDTO model;
            for (int i = 0; i < Assign.Count(); i++)
            {
                model = Mapper.Map<AssignmentDTO>(Assign[i]);
                AssignmentModel.Add(model);
            }

            return AssignmentModel;
        }

        public AssignmentDTO FindById(int id)
        {
            AssignmentDTO model = new AssignmentDTO();
            AssignmentModel = AssignmentService.Find(id);

            Mapper.CreateMap<DataGateway.DAL2.Models.Assignments, AssignmentDTO>();
            model = Mapper.Map<AssignmentDTO>(AssignmentModel);
            return model;
        }

        public void Transform_Assignments_AssignmentsDTO(AssignmentDTO model)
        {
            Mapper.CreateMap<AssignmentDTO, DataGateway.DAL2.Models.Assignments>();
            AssignmentModel = Mapper.Map<DataGateway.DAL2.Models.Assignments>(model);
        }

        public void Dispose()
        {
            AssignmentService.Dispose();
        }
    }
}
