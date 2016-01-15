using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.DataGateway.DAL2.Models
{
    public class UserRoles
    {
        [Key]
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public virtual Users Users { get; set; }
    }
}
