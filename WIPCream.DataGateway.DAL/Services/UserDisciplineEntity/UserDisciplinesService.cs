using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.UserDisciplineEntity
{
    public class UserDisciplinesService:IUserDisciplinesService
    {
        private WIPCream2 db;

        public UserDisciplinesService()
        {
            db = new WIPCream2();
        }

        public string CreateEntity(UserDisciplines model)
        {
            string transactionMessage = "";
            try
            {
                db.UserDisciplines.Add(model);
                db.SaveChanges();
                transactionMessage = "Succes!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;

        }

        public UserDisciplines Find(int id)
        {
            return db.UserDisciplines.Find(id);
        }

        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                UserDisciplines userDiscipline = db.UserDisciplines.Find(id);
                db.UserDisciplines.Remove(userDiscipline);
                db.SaveChanges();
                transactionMessage = "UserDiscipline removed!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(UserDisciplines model)
        {
            String transactionMessage = null;
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                transactionMessage = "UserDiscipline updated!";
            }
            catch (Exception ex)
            {

                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public WIPCream2 GetDB()
        {
            return db;
        }

        public List<UserDisciplines> RetrieveAll()
        {
            return db.UserDisciplines.ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
