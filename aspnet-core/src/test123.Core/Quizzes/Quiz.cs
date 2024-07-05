using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test123.Courses;

namespace test123.Quizzes
{
    public class Quiz : Entity<int>
    {
        public string Title { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }

        // Navigation property for questions
        public virtual ICollection<Question> Questions { get; set; }

        public Quiz()
        {
            Questions = new HashSet<Question>();
        }
    }
}
