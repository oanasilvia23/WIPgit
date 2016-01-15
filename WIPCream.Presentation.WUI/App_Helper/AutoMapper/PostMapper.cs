using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.Presentation.WUI.Models.Post;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class PostMapper
    {
        public static List<PostUIDTO> GetPostUIDTOList(List<PostDTO> PostList)
        {
            Mapper.CreateMap<List<PostDTO>, List<PostUIDTO>>();
            List<PostUIDTO> postUIDTO = new List<PostUIDTO>();
            PostUIDTO model;
            foreach (var item in PostList)
            {
                Mapper.CreateMap<PostDTO, PostUIDTO>();
                model = Mapper.Map<PostUIDTO>(item);
                postUIDTO.Add(model);
            }
            return postUIDTO;
        }

        public static PostDTO GetPostDTO(PostUIDTO Post)
        {
            Mapper.CreateMap<PostUIDTO, PostDTO>();
            return Mapper.Map<PostDTO>(Post);
        }

        public static PostUIDTO GetPostUIDTO(PostDTO Post)
        {
            Mapper.CreateMap<PostDTO, PostUIDTO>();
            return Mapper.Map<PostUIDTO>(Post);
        }
    }
}