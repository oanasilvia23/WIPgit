﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class destinationListDTO
    {
        public destinationDTO Filter { get; set; }
        public List<destinationDTO> Destinations { get; set; }
    }
}
