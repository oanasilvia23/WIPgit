using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.DataGateway.DAL2.Models
{
    public class Threads
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Threads()
        {
            this.Posts = new List<Posts>();
        }

        [Key]
        public int threadid { get; set; }
        public string Email { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
