using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.UserDisciplines;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.UserDiscipline;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class UserDisciplineHelper
    {
        private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);

        public UserDisciplineListUIDTO GetUserDisciplines(UserDisciplineUIDTO filter, int page)
        {
            IUserDisciplineBusinessService userDisciplineService = new UserDisciplineBusinessService();
            var userDisciplines = userDisciplineService.RetrieveAll();
            var userDisciplinesUi = UserDisciplineMapper.GetUserDisciplineUIDTOList(userDisciplines);
            var model = new UserDisciplineListUIDTO();

            model.UserDisciplines = userDisciplinesUi.ToPagedList(page, pageSize);
            model.Filter = new UserDisciplineUIDTO();
            return model;
        }
    }
}