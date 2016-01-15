using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.Question
{
    public class QuestionListUIDTO
    {
        public QuestionUIDTO Filter { get; set; }
        public IPagedList<QuestionUIDTO> Questions { get; set; }
    }
}
