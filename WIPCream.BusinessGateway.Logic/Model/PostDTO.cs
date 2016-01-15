using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class PostDTO
    {
        public int postid { get; set; }
        public Nullable<int> threadid { get; set; }
        public string Email { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string message { get; set; }

        public virtual Threads Thread { get; set; }
    }
}
