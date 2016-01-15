using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Services.Question
{
    public interface IQuestionBusinessService
    {
        string RegisterQuestion(QuestionDTO model);
        string Delete(int id);
        List<QuestionDTO> RetrieveAll();
        QuestionDTO FindById(int id);
        string Update(QuestionDTO Question);
        WIPCream2 getDB();
        void Dispose();
    }
}
