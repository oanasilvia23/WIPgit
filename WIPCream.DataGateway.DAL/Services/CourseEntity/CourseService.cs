using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.CourseEntity
{
    public class CourseService:ICourseService
    {
        private WIPCream2 db2;

        public CourseService()
        {
            db2 = new WIPCream2();
        }

        public string CreateEntity(Courses model)
        {
            string transactionMessage = "";
            try
            {
                db2.Courses.Add(model);
                db2.SaveChanges();
                transactionMessage = "Succes!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;
        }

        public Courses Find(int id)
        {
            return db2.Courses.Find(id);
        }

        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                Courses courses = db2.Courses.Find(id);
                db2.Courses.Remove(courses);
                db2.SaveChanges();
                transactionMessage = "Course removed!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(Courses model)
        {
            String transactionMessage = null;
            try
            {
                db2.Entry(model).State = EntityState.Modified;
                db2.SaveChanges();
                transactionMessage = "Course updated!";
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

        public List<Courses> RetrieveAll()
        {
            return db2.Courses.ToList();
        }
        public void Dispose()
        {
            db2.Dispose();
        }
    }
}
