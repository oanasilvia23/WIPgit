using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.Presentation.WUI.Models.Thread
{
    public class ThreadUIDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThreadUIDTO()
        {
            this.Posts = new List<Posts>();
        }
        public int threadid { get; set; }
        public string Email { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posts> Posts { get; set; }
    }
}