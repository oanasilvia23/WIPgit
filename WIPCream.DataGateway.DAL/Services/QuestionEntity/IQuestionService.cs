using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.QuestionEntity
{
    public interface IQuestionService
    {
        string CreateEntity(Questions model);
        Questions Find(int id);
        string DeleteEntity(int id);
        string UpdateEntity(Questions model);
        List<Questions> RetrieveAll();
        WIPCream2 GetDB();
        void Dispose();
    }
}
