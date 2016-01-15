using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class UserRoleListDO
    {
        public UserRoleDTO Filter { get; set; }
        public List<UserRoleDTO> Users { get; set; }
    }
}
