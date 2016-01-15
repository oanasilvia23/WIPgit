using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.DataGateway.DAL2.Models
{
    public class destination
    {
        [Key]
        public int DestinationID { get; set; }
        public string LocationName { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string TouristTarget { get; set; }
        public int Cost { get; set; }
    }
}
