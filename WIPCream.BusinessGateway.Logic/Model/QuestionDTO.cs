using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.DataGateway.DAL2.Models;

namespace WIPCream.BusinessGateway.Logic.Model
{

    public class QuestionDTO
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        public int CorrectAnswer { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Dictionary<int, string> Answers { get; set; }
    }
}
