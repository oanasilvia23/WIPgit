using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.Presentation.WUI.Models.Thread;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class ThreadMapper
    {
        public static List<ThreadUIDTO> GetThreadUIDTOList(List<ThreadDTO> ThreadList)
        {
            Mapper.CreateMap<List<ThreadDTO>, List<ThreadUIDTO>>();
            List<ThreadUIDTO> ThreadUIDTO = new List<ThreadUIDTO>();
            ThreadUIDTO model;
            foreach (var item in ThreadList)
            {
                Mapper.CreateMap<ThreadDTO, ThreadUIDTO>();
                model = Mapper.Map<ThreadUIDTO>(item);
                ThreadUIDTO.Add(model);
            }
            return ThreadUIDTO;
        }

        public static ThreadDTO GetThreadDTO(ThreadUIDTO Thread)
        {
            Mapper.CreateMap<ThreadUIDTO, ThreadDTO>();
            return Mapper.Map<ThreadDTO>(Thread);
        }

        public static ThreadUIDTO GetThreadUIDTO(ThreadDTO Thread)
        {
            Mapper.CreateMap<ThreadDTO, ThreadUIDTO>();
            return Mapper.Map<ThreadUIDTO>(Thread);
        }
    }
}