using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class UsersListDTO
    {
        public UsersDTO Filter { get; set; }
        public List<UsersDTO> Users { get; set; }
    }
}
