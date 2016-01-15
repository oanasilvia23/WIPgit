using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.UserDiscipline
{
    public class UserDisciplineListUIDTO
    {
        public UserDisciplineUIDTO Filter { get; set; }
        public IPagedList<UserDisciplineUIDTO> UserDisciplines { get; set; }
    }
}