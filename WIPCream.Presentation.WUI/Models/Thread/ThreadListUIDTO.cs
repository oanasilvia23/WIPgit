using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.Thread
{
    public class ThreadListUIDTO
    {
        public ThreadUIDTO Filter { get; set; }
        public IPagedList<ThreadUIDTO> Threads { get; set; }
    }
}