using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.Disciplines;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Discipline;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class DisciplineHelper
    {
        private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);

        public DisciplineListUIDTO GetDisciplines(DisciplineUIDTO filter, int page)
        {
            IDisciplineBusinessService disciplineService = new DisciplineBusinessService();
            var disciplines = disciplineService.RetrieveAll();
            var disciplinesUi = DisciplineMapper.GetDisciplineUIDTOList(disciplines);
            var model = new DisciplineListUIDTO();

            model.Disciplines = disciplinesUi.ToPagedList(page, pageSize);
            model.Filter = new DisciplineUIDTO();
            return model;
        }
    }
}