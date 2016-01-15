using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.ThreadEntity
{
    public class ThreadService:IThreadService
    {
        private WIPCream2 db2;

        public ThreadService()
        {
            db2 = new WIPCream2();
        }

        public string CreateEntity(Threads model)
        {
            string transactionMessage = "";
            try
            {
                db2.Threads.Add(model);
                db2.SaveChanges();
                transactionMessage = "Succes!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;
        }

        public Threads Find(int id)
        {
            return db2.Threads.Find(id);
        }

        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                Threads threads = db2.Threads.Find(id);
                db2.Threads.Remove(threads);
                db2.SaveChanges();
                transactionMessage = "Thread removed!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(Threads model)
        {
            String transactionMessage = null;
            try
            {
                db2.Entry(model).State = EntityState.Modified;
                db2.SaveChanges();
                transactionMessage = "Thread updated!";
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

        public List<Threads> RetrieveAll()
        {
            return db2.Threads.ToList();
        }
        public void Dispose()
        {
            db2.Dispose();
        }
    }
}
