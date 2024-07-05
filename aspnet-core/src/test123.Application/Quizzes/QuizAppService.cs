using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test123.Quizzes.Dto;

namespace test123.Quizzes
{
    public class QuizAppService : ApplicationService, IQuizAppService
    {
        private readonly IRepository<Quiz> _quizRepository;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Option> _optionRepository;

        public QuizAppService(IRepository<Quiz> quizRepository, IRepository<Question> questionRepository, IRepository<Option> optionRepository)
        {
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
            _optionRepository = optionRepository;
        }

        public void CreateQuiz(CreateQuizDto input)
        {
            var existingQuiz = _quizRepository.FirstOrDefault(p => p.Title == input.Title && p.CourseId == input.CourseId);
            if (existingQuiz != null)
            {
                throw new UserFriendlyException("Quiz already exists for this course.");
            }

            var newQuiz = new Quiz { Title = input.Title, CourseId = input.CourseId };
            _quizRepository.Insert(newQuiz);
            CurrentUnitOfWork.SaveChanges();

            foreach (var questionDto in input.Questions)
            {
                var newQuestion = new Question { Text = questionDto.Text, QuizId = newQuiz.Id };
                _questionRepository.Insert(newQuestion);
                CurrentUnitOfWork.SaveChanges();

                foreach (var optionDto in questionDto.Options)
                {
                    var newOption = new Option { Text = optionDto.Text, IsCorrect = optionDto.IsCorrect, QuestionId = newQuestion.Id };
                    _optionRepository.Insert(newOption);
                }
            }

            CurrentUnitOfWork.SaveChanges();
        }

        public void UpdateQuiz(UpdateQuizDto input)
        {
            var quiz = _quizRepository.GetAll().Include(q => q.Questions).ThenInclude(o => o.Options).FirstOrDefault(q => q.Id == input.Id);
            if (quiz == null)
            {
                throw new EntityNotFoundException(typeof(Quiz), input.Id);
            }
            quiz.Title = input.Title;
            quiz.CourseId = input.CourseId;

            foreach (var questionDto in input.Questions)
            {
                var question = quiz.Questions.FirstOrDefault(q => q.Id == questionDto.Id);
                if (question != null)
                {
                    question.Text = questionDto.Text;

                    foreach (var optionDto in questionDto.Options)
                    {
                        var option = question.Options.FirstOrDefault(o => o.Id == optionDto.Id);
                        if (option != null)
                        {
                            option.Text = optionDto.Text;
                            option.IsCorrect = optionDto.IsCorrect;
                            _optionRepository.Update(option); 
                            CurrentUnitOfWork.SaveChanges();
                        }
                        else
                        {
                            var newOption = new Option
                            {
                                Text = optionDto.Text,
                                IsCorrect = optionDto.IsCorrect,
                                QuestionId = question.Id
                            };
                            _optionRepository.Insert(newOption);
                            CurrentUnitOfWork.SaveChanges();
                        }
                    }
                }
                else
                {
                    var newQuestion = new Question
                    {
                        Text = questionDto.Text,
                        QuizId = quiz.Id,
                        Options = questionDto.Options.Select(o => new Option
                        {
                            Text = o.Text,
                            IsCorrect = o.IsCorrect
                        }).ToList()
                    };
                    quiz.Questions.Add(newQuestion);
                }
            }

            _quizRepository.Update(quiz); 
            CurrentUnitOfWork.SaveChanges();
        }


        public QuizDto GetQuizById(int id)
        {
            var quiz = _quizRepository.GetAllIncluding(q => q.Questions).FirstOrDefault(q => q.Id == id);
            if (quiz == null)
            {
                throw new EntityNotFoundException(typeof(Quiz), id);
            }

            return ObjectMapper.Map<QuizDto>(quiz);
        }

        public List<QuizDto> GetAllQuizzes()
        {
            var quizzes = _quizRepository.GetAllIncluding(q => q.Questions).ToList();
            return ObjectMapper.Map<List<QuizDto>>(quizzes);
        }

        public void DeleteQuiz(int id)
        {
            var quiz = _quizRepository.GetAllIncluding(q => q.Questions).FirstOrDefault(q => q.Id == id);
            if (quiz == null)
            {
                throw new EntityNotFoundException(typeof(Quiz), id);
            }

            _quizRepository.Delete(quiz);
            CurrentUnitOfWork.SaveChanges();
        }

        public void DeleteQuestion(int questionId)
        {
            var question = _questionRepository.GetAllIncluding(q => q.Options).FirstOrDefault(q => q.Id == questionId);
            if (question == null)
            {
                throw new EntityNotFoundException(typeof(Question), questionId);
            }

            _questionRepository.Delete(question);
            CurrentUnitOfWork.SaveChanges();
        }

        public void DeleteOption(int optionId)
        {
            var option = _optionRepository.FirstOrDefault(o => o.Id == optionId);
            if (option == null)
            {
                throw new EntityNotFoundException(typeof(Option), optionId);
            }

            _optionRepository.Delete(option);
            CurrentUnitOfWork.SaveChanges();
        }
    }
}
