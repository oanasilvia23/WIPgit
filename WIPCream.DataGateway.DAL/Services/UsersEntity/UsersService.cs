using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.UsersEntity
{
    public class UsersService:IUsersService
    {
        private WIPCream2 db;

        public UsersService()
        {
            db = new WIPCream2();
        }

        public string CreateEntity(Users model)
        {
            string transactionMessage = "";
            try
            {
                    db.Users.Add(model);
                    db.SaveChanges();
                    transactionMessage = "Succes!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;

        }

        public Users Find(int id)
        {
            return db.Users.Find(id);
        }

        public Users FindByEmail(string email)
        {
            List<Users> list = RetrieveAll();
            for(int i=0;i<list.Count;i++)
                if (list[i].Email.Equals(email))
                    return list[i];
            return null;
        }

        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                Users users = db.Users.Find(id);
                db.Users.Remove(users);
                db.SaveChanges();
                transactionMessage = "User removed!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(Users model)
        {
            String transactionMessage = null;
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                transactionMessage = "User updated!";
            }
            catch(Exception ex) {

                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public List<Users> RetrieveAll()
        {

          return db.Users.ToList();
        }

        public void Dispose()
        {
                db.Dispose();
        }
    }
}
