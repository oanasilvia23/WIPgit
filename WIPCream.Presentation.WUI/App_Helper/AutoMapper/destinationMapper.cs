using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.Presentation.WUI.Models.PW9;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class destinationMapper
    {
        public static List<destinationUIDTO> GetDestinationUIDTOList(List<destinationDTO> DestinationList)
        {
            Mapper.CreateMap<List<destinationDTO>, List<destinationUIDTO>>();
            List<destinationUIDTO> DestinationUIDTO = new List<destinationUIDTO>();
            destinationUIDTO model;
            foreach (var item in DestinationList)
            {
                Mapper.CreateMap<destinationDTO, destinationUIDTO>();
                model = Mapper.Map<destinationUIDTO>(item);
                DestinationUIDTO.Add(model);
            }
            return DestinationUIDTO;
        }

        public static destinationDTO GetDestinationDTO(destinationUIDTO destination)
        {
            Mapper.CreateMap<destinationUIDTO, destinationDTO>();
            return Mapper.Map<destinationDTO>(destination);
        }

        public static destinationUIDTO GetDestinationUIDTO(destinationDTO destination)
        {
            Mapper.CreateMap<destinationDTO, destinationUIDTO>();
            return Mapper.Map<destinationUIDTO>(destination);
        }
    }
}