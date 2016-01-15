using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class ThreadListDTO
    {
        public ThreadDTO Filter { get; set; }
        public List<ThreadDTO> Threads { get; set; }
    }
}
