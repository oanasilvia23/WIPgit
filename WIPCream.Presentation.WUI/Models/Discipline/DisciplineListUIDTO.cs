using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.Discipline
{
    public class DisciplineListUIDTO
    {
        public DisciplineUIDTO Filter { get; set; }
        public IPagedList<DisciplineUIDTO> Disciplines { get; set; }
    }
}