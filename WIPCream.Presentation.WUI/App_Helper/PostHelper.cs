using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Services.Post;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Post;

namespace WIPCream.Presentation.WUI.App_Helper
{
    public class PostHelper
    {
        private int pageSize = int.Parse(ConfigurationManager.AppSettings["gridrows"]);

        public PostListUIDTO GetPosts(PostUIDTO filter, int page)
        {
            IPostBusinessService PostService = new PostBusinessService();
            var Posts = PostService.RetrieveAll();
            var PostsUi = PostMapper.GetPostUIDTOList(Posts);
            var model = new PostListUIDTO();

            model.Posts = PostsUi.ToPagedList(page, pageSize);
            model.Filter = new PostUIDTO();
            return model;
        }
    }
}