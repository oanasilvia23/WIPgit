using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.DisciplineEntity
{
    public class DisciplineService:IDisciplineService
    {
        private WIPCream2 db2;

        public DisciplineService()
        {
            db2 = new WIPCream2();
        }

        public string CreateEntity(Disciplines model)
        {
            string transactionMessage = "";
            try
            {
                db2.Disciplines.Add(model);
                db2.SaveChanges();
                transactionMessage = "Succes!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;
        }

        public Disciplines Find(int id)
        {
            return db2.Disciplines.Find(id);
        }

        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                Disciplines discipline = db2.Disciplines.Find(id);
                db2.Disciplines.Remove(discipline);
                db2.SaveChanges();
                transactionMessage = "UserDiscipline removed!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(Disciplines model)
        {
            String transactionMessage = null;
            try
            {
                db2.Entry(model).State = EntityState.Modified;
                db2.SaveChanges();
                transactionMessage = "Discipline updated!";
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

        public List<Disciplines> RetrieveAll()
        {
            return db2.Disciplines.ToList();
        }
        public void Dispose()
        {
            db2.Dispose();
        }
    }
}
