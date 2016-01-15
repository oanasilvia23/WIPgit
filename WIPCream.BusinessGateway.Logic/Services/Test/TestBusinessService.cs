using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.TestEntity;

namespace WIPCream.BusinessGateway.Logic.Services.Test
{
    public class TestBusinessService:ITestBusinessService
    {
        private ITestService testService;
        private Tests testModel;

        public TestBusinessService()
        {
            testService = new TestSevice();
        }

        public WIPCream2 getDB()
        {
            return testService.GetDB();
        }

        public string ResgisterTest(TestDTO model)
        {
            String transactionmessage = null;
            Transform_Tests_TestsDTO(model);
            transactionmessage = testService.CreateEntity(testModel);
            return transactionmessage;
        }

        public string Delete(int id)
        {
            String transactionmessage = null;
            transactionmessage = testService.DeleteEntity(id);
            return transactionmessage;
        }

        public string Update(TestDTO test)
        {
            String transactionmessage = null;
            Transform_Tests_TestsDTO(test);
            transactionmessage = testService.UpdateEntity(testModel);
            return transactionmessage;
        }

        public List<TestDTO> RetrieveAll()
        {
            List<TestDTO> TestModel = new List<TestDTO>();
            List<Tests> Tests = testService.RetrieveAll();
            Mapper.CreateMap<Tests, TestDTO>();
            TestDTO model;
            for (int i = 0; i < Tests.Count(); i++)
            {
                model = Mapper.Map<TestDTO>(Tests[i]);
                TestModel.Add(model);
            }

            return TestModel;
        }

        public TestDTO FindById(int id)
        {
            TestDTO model = new TestDTO();
            testModel = testService.Find(id);

            Mapper.CreateMap<Tests, TestDTO>();
            model = Mapper.Map<TestDTO>(testModel);
            return model;
        }

        public void Transform_Tests_TestsDTO(TestDTO model)
        {
            Mapper.CreateMap<TestDTO, Tests>();
            testModel = Mapper.Map<Tests>(model);
        }

        public void Dispose()
        {
            testService.Dispose();
        }
    }
}
