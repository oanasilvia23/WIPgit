using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.Assignments;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Assignment;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class AssignmentHelper
    {
        private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);

        public AssignmentListUIDTO GetAssignments(AssignmentUIDTO filter, int page)
        {
            IAssignmentBusinessSerevice AssignmentService = new AssignmentBusinessService();
            var Assignments = AssignmentService.RetrieveAll();
            var AssignmentsUi = AssignmentMapper.GetAssignmentUIDTOList(Assignments);
            var model = new AssignmentListUIDTO();

            model.Assignments = AssignmentsUi.ToPagedList(page, pageSize);
            model.Filter = new AssignmentUIDTO();
            return model;
        }
    }
}