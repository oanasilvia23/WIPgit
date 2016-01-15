using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.Presentation.WUI.Models.Post
{
    public class PostUIDTO
    {
        public int postid { get; set; }
        public Nullable<int> threadid { get; set; }
        public Nullable<int> userid { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string message { get; set; }

        public virtual Threads Thread { get; set; }
    }
}