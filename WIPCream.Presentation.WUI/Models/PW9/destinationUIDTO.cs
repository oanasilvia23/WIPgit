using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.PW9
{
    public class destinationUIDTO
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