using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class DisciplineListDTO
    {
        public DisciplineDTO Filter { get; set; }
        public List<DisciplineDTO> Disciplines { get; set; }
    }
}
