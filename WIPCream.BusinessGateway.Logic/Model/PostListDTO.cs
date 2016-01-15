using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class PostListDTO
    {
        public PostDTO Filter { get; set; }
        public List<PostDTO> Posts { get; set; }
    }
}
