using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.TestEntity
{
    public class TestSevice:ITestService
    {
        private WIPCream2 db2;

        public TestSevice()
        {
            db2 = new WIPCream2();
        }

        public string CreateEntity(Tests model)
        {
            string transactionMessage = "";
            try
            {
                db2.Tests.Add(model);
                db2.SaveChanges();
                transactionMessage = "Succes!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;
        }

        public Tests Find(int id)
        {
            return db2.Tests.Find(id);
        }

        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                Tests tests = db2.Tests.Find(id);
                db2.Tests.Remove(tests);
                db2.SaveChanges();
                transactionMessage = "Test removed!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(Tests model)
        {
            String transactionMessage = null;
            try
            {
                db2.Entry(model).State = EntityState.Modified;
                db2.SaveChanges();
                transactionMessage = "Test updated!";
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

        public List<Tests> RetrieveAll()
        {
            return db2.Tests.ToList();
        }
        public void Dispose()
        {
            db2.Dispose();
        }
    }
}
