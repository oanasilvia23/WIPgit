using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Services.Post
{
    public interface IPostBusinessService
    {
        string ResgisterPost(PostDTO model);
        string Delete(int id);
        List<PostDTO> RetrieveAll();
        List<PostDTO> FindPostByThreadId(int id);
        PostDTO FindById(int id);
        string Update(PostDTO Post);
        WIPCream2 getDB();
        void Dispose();
    }
}
