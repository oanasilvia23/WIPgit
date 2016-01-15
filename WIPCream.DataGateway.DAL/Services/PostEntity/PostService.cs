using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.PostEntity
{
    public class PostService:IPostService
    {
        private WIPCream2 db2;

        public PostService()
        {
            db2 = new WIPCream2();
        }

        public string CreateEntity(Posts model)
        {
            string transactionMessage = "";
            try
            {
                db2.Posts.Add(model);
                db2.SaveChanges();
                transactionMessage = "Succes!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;
        }

        public Posts Find(int id)
        {
            return db2.Posts.Find(id);
        }

        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                Posts Posts = db2.Posts.Find(id);
                db2.Posts.Remove(Posts);
                db2.SaveChanges();
                transactionMessage = "Post removed!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(Posts model)
        {
            String transactionMessage = null;
            try
            {
                db2.Entry(model).State = EntityState.Modified;
                db2.SaveChanges();
                transactionMessage = "Post updated!";
            }
            catch (Exception ex)
            {

                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public List<Posts> getByThreadId(int id)
        {
            var posts = db2.Posts;
            List<Posts> list = new List<Posts>();
            foreach (var item in posts)
                if (item.threadid == id)
                    list.Add(item);
            return list;
        }

        public WIPCream2 GetDB()
        {
            return db2;
        }

        public List<Posts> RetrieveAll()
        {
            var posts = db2.Posts.Include(p => p.Thread);
            return posts.ToList();
        }
        public void Dispose()
        {
            db2.Dispose();
        }
    }
}
