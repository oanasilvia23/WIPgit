using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.UserRoles;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.UserRole;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class UserRoleHelper
    {
        private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);

        public UserRoleListUIDTO GetRoles(UserRoleUIDTO filter, int page)
        {
            IUserRoleBusinessService roleService = new UserRoleBusinessService();
            var roles = roleService.RetrieveAll();
            var rolesUi = UserRoleMapper.GetUserRoleUIDTOList(roles);
            var model = new UserRoleListUIDTO();

            model.Roles = rolesUi.ToPagedList(page, pageSize);
            model.Filter = new UserRoleUIDTO();
            return model;
        }
    }
}