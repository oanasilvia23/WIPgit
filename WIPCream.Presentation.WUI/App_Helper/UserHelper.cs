using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.User;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.User;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class UserHelper
    {
        private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);

        public UserListUIDTO GetUsers(UserUIDTO filter, int page)
        {
            IUsersBusinessService userService = new UserBusinessService();
            var users = userService.RetrieveAll();
            var usersUi = UserMapper.GetUserUIDTOList(users);
            var model = new UserListUIDTO();

            model.Users = usersUi.ToPagedList(page, pageSize);
            model.Filter = new UserUIDTO();
            return model;
        }
    }
}