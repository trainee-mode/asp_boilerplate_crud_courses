using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test123.Quizzes;

namespace test123.Quizzes.Dto
{
    [AutoMapFrom(typeof(Quiz))]
    public class UpdateQuizDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Guid CourseId { get; set; }
        public List<UpdateQuestionDto> Questions { get; set; }
    }
}
