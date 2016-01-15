using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.Question;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Question;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class QuestionHelper
    {
        private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);

        public QuestionListUIDTO GetQuestions(QuestionUIDTO filter, int page)
        {
            IQuestionBusinessService QuestionService = new QuestionBusinessService();
            var Questions = QuestionService.RetrieveAll();
            var QuestionsUi = QuestionMapper.GetQuestionUIDTOList(Questions);
            var model = new QuestionListUIDTO();

            model.Questions = QuestionsUi.ToPagedList(page, pageSize);
            model.Filter = new QuestionUIDTO();
            return model;
        }
    }
}
