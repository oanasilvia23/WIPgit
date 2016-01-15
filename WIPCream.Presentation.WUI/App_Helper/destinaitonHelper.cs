using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.Destinations;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.PW9;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class destinaitonHelper
    {
        //private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);
        private static int pageSize = 10;

        public destinationListUIDTO GetDestinations(destinationUIDTO filter, int page)
        {
            IDestinationBusinessService destinationService = new DestinationBusinessService();
            var destinations = destinationService.RetrieveAll();
            var destinationsUi = destinationMapper.GetDestinationUIDTOList(destinations);
            var model = new destinationListUIDTO();

            model.Destinations = destinationsUi.ToPagedList(page, pageSize);
            model.Filter = new destinationUIDTO();
            return model;
        }
    }
}