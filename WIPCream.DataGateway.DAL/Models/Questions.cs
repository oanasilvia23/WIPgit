using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.DataGateway.DAL2.Models
{
    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        public int CorrectAnswer { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Dictionary<int, string> Answers { get; set; }
    }
}
