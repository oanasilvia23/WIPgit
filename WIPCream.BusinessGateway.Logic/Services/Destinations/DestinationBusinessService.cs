using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.DestinationEntity;

namespace WIPCream.BusinessGateway.Logic.Services.Destinations
{
    public class DestinationBusinessService:IDestinationBusinessService
    {
        private IDestinationService destinationService;
        private destination destinationModel;

        public DestinationBusinessService()
        {
            destinationService = new DestinationService();
        }

        public WIPCream2 getDB()
        {
            return destinationService.GetDB();
        }

        public string ResgisterDestination(destinationDTO model)
        {
            String transactionmessage = null;
            Transform_Destinations_DestinationsDTO(model);
            transactionmessage = destinationService.CreateEntity(destinationModel);
            return transactionmessage;
        }

        public string Delete(int id)
        {
            String transactionmessage = null;
            transactionmessage = destinationService.DeleteEntity(id);
            return transactionmessage;
        }

        public string Update(destinationDTO destination)
        {
            String transactionmessage = null;
            Transform_Destinations_DestinationsDTO(destination);
            transactionmessage = destinationService.UpdateEntity(destinationModel);
            return transactionmessage;
        }

        public List<destinationDTO> RetrieveAll()
        {
            List<destinationDTO> destinationModel = new List<destinationDTO>();
            List<destination> destinations = destinationService.RetrieveAll();
            Mapper.CreateMap<destination, destinationDTO>();
            destinationDTO model;
            for (int i = 0; i < destinations.Count(); i++)
            {
                model = Mapper.Map<destinationDTO>(destinations[i]);
                destinationModel.Add(model);
            }

            return destinationModel;
        }

        public destinationDTO FindById(int id)
        {
            destinationDTO model = new destinationDTO();
            destinationModel = destinationService.Find(id);

            Mapper.CreateMap<destination, destinationDTO>();
            model = Mapper.Map<destinationDTO>(destinationModel);
            return model;
        }

        public void Transform_Destinations_DestinationsDTO(destinationDTO model)
        {
            Mapper.CreateMap<destinationDTO, destination>();
            destinationModel = Mapper.Map<destination>(model);
        }

        public void Dispose()
        {
            destinationService.Dispose();
        }
    }
}
