using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test123.Quizzes.Dto;

namespace test123.Quizzes
{
    public interface IQuizAppService : IApplicationService
    {
        void CreateQuiz(CreateQuizDto input);
        void UpdateQuiz(UpdateQuizDto input);
        QuizDto GetQuizById(int id);
        List<QuizDto> GetAllQuizzes();
        void DeleteQuiz(int id);
        void DeleteQuestion(int questionId); 
        void DeleteOption(int optionId);
    }
}
