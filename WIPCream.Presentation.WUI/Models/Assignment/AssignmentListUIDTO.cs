using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.Assignment
{
    public class AssignmentListUIDTO
    {
        public AssignmentUIDTO Filter { get; set; }
        public IPagedList<AssignmentUIDTO> Assignments { get; set; }
    }
}