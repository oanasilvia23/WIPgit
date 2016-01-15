using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.BusinessGateway.Logic.Model
{
    public class QuestionListDTO
    {
        public QuestionDTO Filter { get; set; }
        public List<QuestionDTO> Questions { get; set; }
    }
}
