using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.DataGateway.DAL2.Services.DestinationEntity
{
    public class DestinationService:IDestinationService
    {
        private WIPCream2 db2;

        public DestinationService()
        {
            db2 = new WIPCream2();
        }

        public string CreateEntity(destination model)
        {
            string transactionMessage = "";
            try
            {
                db2.destinations.Add(model);
                db2.SaveChanges();
                transactionMessage = "Succes!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error " + ex.Message;
            }
            return transactionMessage;
        }

        public destination Find(int id)
        {
            return db2.destinations.Find(id);
        }

        public string DeleteEntity(int id)
        {
            string transactionMessage = "";
            try
            {
                destination destinaiton = db2.destinations.Find(id);
                db2.destinations.Remove(destinaiton);
                db2.SaveChanges();
                transactionMessage = "Destination removed!";
            }
            catch (Exception ex)
            {
                transactionMessage = "Error: " + ex.Message;
            }
            return transactionMessage;
        }

        public string UpdateEntity(destination model)
        {
            String transactionMessage = null;
            try
            {
                db2.Entry(model).State = EntityState.Modified;
                db2.SaveChanges();
                transactionMessage = "Destination updated!";
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

        public List<destination> RetrieveAll()
        {
            return db2.destinations.ToList();
        }
        public void Dispose()
        {
            db2.Dispose();
        }
    }
}
