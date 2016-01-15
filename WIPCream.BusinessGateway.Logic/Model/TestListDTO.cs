using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class TestListDTO
    {
        public TestDTO Filter { get; set; }
        public List<TestDTO> Tests { get; set; }
    }
}
