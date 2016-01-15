using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.Presentation.WUI.Models.Test;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class TestMapper
    {
        public static List<TestUIDTO> GetTestUIDTOList(List<TestDTO> TestList)
        {
            Mapper.CreateMap<List<TestDTO>, List<TestUIDTO>>();
            List<TestUIDTO> TestUIDTO = new List<TestUIDTO>();
            TestUIDTO model;
            foreach (var item in TestList)
            {
                Mapper.CreateMap<TestDTO, TestUIDTO>();
                model = Mapper.Map<TestUIDTO>(item);
                TestUIDTO.Add(model);
            }
            return TestUIDTO;
        }

        public static TestDTO GetTestDTO(TestUIDTO Test)
        {
            Mapper.CreateMap<TestUIDTO, TestDTO>();
            return Mapper.Map<TestDTO>(Test);
        }

        public static TestUIDTO GetTestUIDTO(TestDTO Test)
        {
            Mapper.CreateMap<TestDTO, TestUIDTO>();
            return Mapper.Map<TestUIDTO>(Test);
        }
    }
}