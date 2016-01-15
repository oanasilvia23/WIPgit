using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.Presentation.WUI.Models.UserRole
{
    public class UserRoleUIDTO
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public virtual Users Users { get; set; }
    }
}