using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.Presentation.WUI.Models.Test
{
    public class TestUIDTO
    {
        public int TestId { get; set; }
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }

        public virtual Disciplines Discipline { get; set; }
        public string Image { get; set; }
    }
}