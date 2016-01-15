using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class UserDisciplineListDTO
    {
        public UserDisciplineDTO Filter { get; set; }
        public List<UserDisciplineDTO> UserDisciplines { get; set; }
    }
}
