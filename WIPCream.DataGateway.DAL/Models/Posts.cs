using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.DataGateway.DAL2.Models
{
    public class Posts
    {
        [Key]
        public int postid { get; set; }
        public Nullable<int> threadid { get; set; }
        public string Email { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string message { get; set; }

        public virtual Threads Thread { get; set; }
    }
}
