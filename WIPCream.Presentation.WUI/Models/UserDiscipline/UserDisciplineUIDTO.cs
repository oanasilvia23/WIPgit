using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.Presentation.WUI.Models.UserDiscipline
{
    public class UserDisciplineUIDTO
    {
        public int UserDisciplineId { get; set; }
        public int UsereId { get; set; }
        public int DisciplineId { get; set; }

        public virtual WIPCream.DataGateway.DAL2.Models.Disciplines Discipline { get; set; }
        public virtual Users Users { get; set; }
    }
}