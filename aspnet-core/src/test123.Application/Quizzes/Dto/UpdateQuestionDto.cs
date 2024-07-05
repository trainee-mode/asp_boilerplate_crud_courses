using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test123.Quizzes;

namespace test123.Quizzes.Dto
{
    [AutoMapFrom(typeof(Question))]
    public class UpdateQuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<UpdateOptionDto> Options { get; set; }
    }
}
