using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.UserRoleEntity
{
    public class UserRoleService:IUserRoleService
    {
        private WIPCream2 db;
        public UserRoleService()
        {
            db = new WIPCream2();
        }

        public string CreateEntity(UserRoles model)
        {
            string transactionMessage = "";
            try
            {
                db.UserRoles.Add(model);
                db.SaveChanges();
                transactionMessage = "Succes!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;
        }

        public WIPCream2 getDB()
        {
            return db;
        }       
        public UserRoles Find(int id)
        {
            return db.UserRoles.Find(id);
        }

        public List<UserRoles> FindByUserId(int id)
        {
            List<UserRoles> list = null;
            List<UserRoles> initList = db.UserRoles.ToList();
            for (int i = 0; i < initList.Count; i++)
            {
                if (initList[i].UserId == id)
                    list.Add(initList[i]);
            }
            return initList;
        }

        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                UserRoles role = db.UserRoles.Find(id);
                db.UserRoles.Remove(role);
                db.SaveChanges();
                transactionMessage = "Role removed!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(UserRoles model)
        {
            String transactionMessage = null;
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                transactionMessage = "Role updated!";
            }
            catch (Exception ex)
            {

                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public List<Users> RetrieveUnassigned()
        {
            var userRole = db.UserRoles.Include(u => u.Users);
            var users = db.Users;
            List<Users> res = new List<Users>();
            foreach (var user in users) {
                bool found = false;
                foreach (var item in userRole)
                    if (item.UserId == user.UserId)
                        found = true;
                if (!found)
                    res.Add(user);
            }
            return res;
        }

        public List<UserRoles> RetrieveAll()
        {
            var userRole = db.UserRoles.Include(u => u.Users);
            return userRole.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
