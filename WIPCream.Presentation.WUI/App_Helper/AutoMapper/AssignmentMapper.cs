using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.Presentation.WUI.Models.Assignment;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class AssignmentMapper
    {
        public static List<AssignmentUIDTO> GetAssignmentUIDTOList(List<AssignmentDTO> AssignmentList)
        {
            Mapper.CreateMap<List<AssignmentDTO>, List<AssignmentUIDTO>>();
            List<AssignmentUIDTO> AssignmentUIDTO = new List<AssignmentUIDTO>();
            AssignmentUIDTO model;
            foreach (var item in AssignmentList)
            {
                Mapper.CreateMap<AssignmentDTO, AssignmentUIDTO>();
                model = Mapper.Map<AssignmentUIDTO>(item);
                AssignmentUIDTO.Add(model);
            }
            return AssignmentUIDTO;
        }

        public static AssignmentDTO GetAssignmentDTO(AssignmentUIDTO Assignment)
        {
            Mapper.CreateMap<AssignmentUIDTO, AssignmentDTO>();
            return Mapper.Map<AssignmentDTO>(Assignment);
        }

        public static AssignmentUIDTO GetAssignmentUIDTO(AssignmentDTO Assignment)
        {
            Mapper.CreateMap<AssignmentDTO, AssignmentUIDTO>();
            return Mapper.Map<AssignmentUIDTO>(Assignment);
        }
    }
}