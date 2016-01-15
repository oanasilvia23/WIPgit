using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.UserRole
{
    public class UserRoleListUIDTO
    {
        public UserRoleUIDTO Filter { get; set; }
        public IPagedList<UserRoleUIDTO> Roles { get; set; }
    }
}