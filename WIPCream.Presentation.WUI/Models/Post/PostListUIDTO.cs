using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIPCream.Presentation.WUI.Models.Post
{
    public class PostListUIDTO
    {
        public PostUIDTO Filter { get; set; }
        public IPagedList<PostUIDTO> Posts { get; set; }
    }
}