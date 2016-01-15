using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.PW9
{
    public class destinationListUIDTO
    {
        public destinationUIDTO Filter { get; set; }
        public IPagedList<destinationUIDTO> Destinations { get; set; }
    }
}