using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test123.Quizzes;

namespace test123.Courses
{
    public class Course : Entity<int>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }

        public Course()
        {
            Quizzes = new HashSet<Quiz>();
        }


    }
}
