using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.AssignmentEntity
{
    public class AssignmentService:IAssignmentService
    {
        private WIPCream2 db2;

        public AssignmentService()
        {
            db2=new WIPCream2();
        }

        public string CreateEntity(Assignments model)
        {
            string transactionMessage = "";
            try
            {
                //db.Assignment.Add(model);
                //db.SaveChanges();
                db2.Assignments.Add(model);
                db2.SaveChanges();
                transactionMessage = "Succes!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;

        }

        public Assignments Find(int id)
        {
            return db2.Assignments.Find(id);
        }

        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                Assignments Assignment = db2.Assignments.Find(id);
                db2.Assignments.Remove(Assignment);
                db2.SaveChanges();
                transactionMessage = "Assignment removed!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(Assignments model)
        {
            String transactionMessage = null;
            try
            {
                db2.Entry(model).State = EntityState.Modified;
                db2.SaveChanges();
                transactionMessage = "Assignment updated!";
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

        public List<Assignments> RetrieveAll()
        {
            return db2.Assignments.ToList();
        }
        public void Dispose()
        {
            db2.Dispose();
        }
    }
}
