using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.QuestionEntity
{
    public class QuestionService: IQuestionService
    {
        private WIPCream2 db2;
        public QuestionService()
        {
            db2 = new WIPCream2();
        }
        public string CreateEntity(Questions model)
        {
            string transactionMessage = "";
            try
            {
                db2.Questions.Add(model);
                db2.SaveChanges();
                transactionMessage = "Success!";
            }
            catch(Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;
        }
        public Questions Find(int id)
        {
            return db2.Questions.Find(id);
        }
        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                Questions questions = db2.Questions.Find(id);
                db2.Questions.Remove(questions);
                db2.SaveChanges();
                transactionMessage = "Question removed!";
            }
            catch(Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(Questions model)
        {
            String transactionMessage = null;
            try
            {
                db2.Entry(model).State = EntityState.Modified;
                db2.SaveChanges();
                transactionMessage = "Question updated!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public WIPCream2 GetDB()
        {
            return db2;
        }
        public List<Questions> RetrieveAll()
        {
            return db2.Questions.ToList();
        }
        public void Dispose()
        {
            db2.Dispose();
        }
    }
}
