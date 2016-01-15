using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.Thread;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Thread;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class ThreadHelper
    {
        private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);

        public ThreadListUIDTO GetThreads(ThreadUIDTO filter, int page)
        {
            IThreadBusinessService ThreadService = new ThreadBusinessService();
            var Threads = ThreadService.RetrieveAll();
            var ThreadsUi = ThreadMapper.GetThreadUIDTOList(Threads);
            var model = new ThreadListUIDTO();

            model.Threads = ThreadsUi.ToPagedList(page, pageSize);
            model.Filter = new ThreadUIDTO();
            return model;
        }
    }
}