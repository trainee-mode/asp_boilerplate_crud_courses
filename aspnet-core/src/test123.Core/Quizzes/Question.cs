using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test123.Quizzes
{
    public class Question : Entity<int>
    {
        public string Text { get; set; }
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        // Navigation property for options
        public virtual ICollection<Option> Options { get; set; }

        public Question()
        {
            Options = new HashSet<Option>();
        }
    }
}
