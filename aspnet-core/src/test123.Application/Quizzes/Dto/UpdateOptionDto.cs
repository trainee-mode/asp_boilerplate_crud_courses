using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test123.Quizzes;

namespace test123.Quizzes.Dto
{
    [AutoMapFrom(typeof(Option))]
    public class UpdateOptionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
