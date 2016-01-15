using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.Test;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Test;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class TestHelper
    {
        private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);

        public TestListUIDTO GetTests(TestUIDTO filter, int page)
        {
            ITestBusinessService TestService = new TestBusinessService();
            var Tests = TestService.RetrieveAll();
            var TestsUi = TestMapper.GetTestUIDTOList(Tests);
            var model = new TestListUIDTO();

            model.Tests = TestsUi.ToPagedList(page, pageSize);
            model.Filter = new TestUIDTO();
            return model;
        }
    }
}