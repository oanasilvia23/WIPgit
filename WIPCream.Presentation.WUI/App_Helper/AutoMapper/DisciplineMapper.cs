using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.Presentation.WUI.Models.Discipline;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class DisciplineMapper
    {
        public static List<DisciplineUIDTO> GetDisciplineUIDTOList(List<DisciplineDTO> disciplineList)
        {
            Mapper.CreateMap<List<DisciplineDTO>, List<DisciplineUIDTO>>();
            List<DisciplineUIDTO> disciplineUIDTO = new List<DisciplineUIDTO>();
            DisciplineUIDTO model;
            foreach (var item in disciplineList)
            {
                Mapper.CreateMap<DisciplineDTO, DisciplineUIDTO>();
                model = Mapper.Map<DisciplineUIDTO>(item);
                disciplineUIDTO.Add(model);
            }
            return disciplineUIDTO;
        }

        public static DisciplineDTO GetDisciplineDTO(DisciplineUIDTO discipline)
        {
            Mapper.CreateMap<DisciplineUIDTO, DisciplineDTO>();
            return Mapper.Map<DisciplineDTO>(discipline);
        }

        public static DisciplineUIDTO GetDisciplineUIDTO(DisciplineDTO discipline)
        {
            Mapper.CreateMap<DisciplineDTO, DisciplineUIDTO>();
            return Mapper.Map<DisciplineUIDTO>(discipline);
        }
    }
}