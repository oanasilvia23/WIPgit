using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace WIPCream.Presentation.WUI.Models.User
{
    public class UserListUIDTO
    {
        public UserUIDTO Filter { get; set; }
        public IPagedList<UserUIDTO> Users { get; set; }
    }
}