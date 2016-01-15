using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.Test
{
    public class TestListUIDTO
    {
        public TestUIDTO Filter { get; set; }
        public IPagedList<TestUIDTO> Tests { get; set; }
    }
}