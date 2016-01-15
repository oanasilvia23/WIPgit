using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.BusinessGateway.Logic.Services.Post;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.ThreadEntity;

namespace WIPCream.BusinessGateway.Logic.Services.Thread
{
    public class ThreadBusinessService:IThreadBusinessService
    {
        private IThreadService ThreadService;
        private Threads ThreadModel;
        private IPostBusinessService postService = new PostBusinessService();

        public ThreadBusinessService()
        {
            ThreadService = new ThreadService();
        }

        public WIPCream2 getDB()
        {
            return ThreadService.GetDB();
        }

        public string ResgisterThread(ThreadDTO model)
        {
            String transactionmessage = null;
            Transform_Threads_ThreadsDTO(model);
            transactionmessage = ThreadService.CreateEntity(ThreadModel);
            return transactionmessage;
        }

        public string Delete(int id)
        {
            String transactionmessage = null;
            transactionmessage = ThreadService.DeleteEntity(id);
            return transactionmessage;
        }

        public string Update(ThreadDTO Thread)
        {
            String transactionmessage = null;
            Transform_Threads_ThreadsDTO(Thread);
            transactionmessage = ThreadService.UpdateEntity(ThreadModel);
            return transactionmessage;
        }

        public List<ThreadDTO> RetrieveAll()
        {
            List<ThreadDTO> ThreadModel = new List<ThreadDTO>();
            List<Threads> Threads = ThreadService.RetrieveAll();
            Mapper.CreateMap<Threads, ThreadDTO>();
            ThreadDTO model;
            for (int i = 0; i < Threads.Count(); i++)
            {
                model = Mapper.Map<ThreadDTO>(Threads[i]);
                ThreadModel.Add(model);
            }

            return ThreadModel;
        }

        public ThreadDTO FindById(int id)
         {
            List<PostDTO> post = postService.FindPostByThreadId(id);
            List<Posts> psots=new List<Posts>();
            Mapper.CreateMap<PostDTO, Posts>();
            foreach (var item in post)
                psots.Add(Mapper.Map<Posts>(item));

            ThreadDTO model = new ThreadDTO();
            ThreadModel = ThreadService.Find(id);

            Mapper.CreateMap<Threads, ThreadDTO>();
            model = Mapper.Map<ThreadDTO>(ThreadModel);
            model.Posts = psots;
            return model;
        }

        public void Transform_Threads_ThreadsDTO(ThreadDTO model)
        {
            Mapper.CreateMap<ThreadDTO, Threads>();
            ThreadModel = Mapper.Map<Threads>(model);
        }

        public void Dispose()
        {
            ThreadService.Dispose();
        }
    }
}
