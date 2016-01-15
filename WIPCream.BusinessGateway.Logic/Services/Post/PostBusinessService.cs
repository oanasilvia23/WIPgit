using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIPCream.DataGateway.DAL2.Services.PostEntity;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.BusinessGateway.Logic.Model;
using AutoMapper;

namespace WIPCream.BusinessGateway.Logic.Services.Post
{
    public class PostBusinessService : IPostBusinessService
    {
        private IPostService PostService;
        private Posts PostModel;

        public PostBusinessService()
        {
            PostService = new PostService();
        }

        public WIPCream2 getDB()
        {
            return PostService.GetDB();
        }

        public string ResgisterPost(PostDTO model)
        {
            String transactionmessage = null;
            Transform_Posts_PostsDTO(model);
            transactionmessage = PostService.CreateEntity(PostModel);
            return transactionmessage;
        }

        public string Delete(int id)
        {
            String transactionmessage = null;
            transactionmessage = PostService.DeleteEntity(id);
            return transactionmessage;
        }

        public string Update(PostDTO Post)
        {
            String transactionmessage = null;
            Transform_Posts_PostsDTO(Post);
            transactionmessage = PostService.UpdateEntity(PostModel);
            return transactionmessage;
        }

        public List<PostDTO> RetrieveAll()
        {
            List<PostDTO> PostModel = new List<PostDTO>();
            List<Posts> Posts = PostService.RetrieveAll();
            Mapper.CreateMap<Posts, PostDTO>();
            PostDTO model;
            for (int i = 0; i < Posts.Count(); i++)
            {
                model = Mapper.Map<PostDTO>(Posts[i]);
                PostModel.Add(model);
            }

            return PostModel;
        }

        public List<PostDTO> FindPostByThreadId(int id)
        {
            List<PostDTO> PostModel = new List<PostDTO>();
            List<Posts> Posts = PostService.getByThreadId(id);
            Mapper.CreateMap<Posts, PostDTO>();
            PostDTO model;
            for (int i = 0; i < Posts.Count(); i++)
            {
                model = Mapper.Map<PostDTO>(Posts[i]);
                PostModel.Add(model);
            }
            return PostModel;
        }

        public PostDTO FindById(int id)
        {
            PostDTO model = new PostDTO();
            PostModel = PostService.Find(id);

            Mapper.CreateMap<Posts, PostDTO>();
            model = Mapper.Map<PostDTO>(PostModel);
            return model;
        }

        public void Transform_Posts_PostsDTO(PostDTO model)
        {
            Mapper.CreateMap<PostDTO, Posts>();
            PostModel = Mapper.Map<Posts>(model);
        }

        public void Dispose()
        {
            PostService.Dispose();
        }
    }
}
