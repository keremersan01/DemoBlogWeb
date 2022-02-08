using DemoBlogWeb.Data;
using DemoBlogWeb.Models;
using DemoBlogWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Dynamic;

namespace DemoBlogWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoBlogDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, DemoBlogDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
           
            IEnumerable<Question> questionList = _dbContext.Questions.Include(o => o.Answers)
                .Include(o => o.QuestionTag).ToList();
            
            QuestionAndTagModel questionAndTagModel = new QuestionAndTagModel();
            questionAndTagModel.QuestionList = questionList;
           
            return View(questionAndTagModel);

        }

        public IActionResult Question(int? id)
        {
            ViewModel mymodel = new ViewModel();
            mymodel.Question = _dbContext.Questions.Include(question => question.Answers)
                .Include(o => o.QuestionTag).SingleOrDefault(u => u.Id == id);
            mymodel.Answer = new Answer();
            mymodel.Answer.Question = mymodel.Question;
            return View(mymodel);
        }

        public IActionResult CreateQuestion()
        {
            QuestionAndTagModel model = new QuestionAndTagModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateQuestion(QuestionAndTagModel obj)
        {
            if (obj.Question.Title == obj.Question.QuestionBody.ToString())
            {
                ModelState.AddModelError("CustomError", "The title should be different from the question body");
            }
                

                obj.Question.QuestionTag = obj.QuestionTag;
                obj.Question.QuestionTag.Name = obj.Question.QuestionTag.Name.ToLower();

                _dbContext.Questions.Add(obj.Question);
              
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            
            
        }

        [HttpPost]
        public IActionResult CreateAnswer(ViewModel model)
        {
            
            Question question = _dbContext.Questions.Find(model.Question.Id);

            model.Answer.Question = question;
                
                    _dbContext.Answers.Add(model.Answer);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult FilterByTag(QuestionAndTagModel model)
        {
            if(model.QuestionTag.Name == null)
            {
                return RedirectToAction("Index");
            }

            var questionTags = _dbContext.QuestionTags.Where(o => o.Name == model.QuestionTag.Name);
            List<Question> questionList = new List<Question>();
            
            foreach(var tag in questionTags)
            {
                Question question = _dbContext.Questions.Where(o => o.QuestionTag.Id == tag.Id).
                    Include(question => question.Answers).Include(o => o.QuestionTag).FirstOrDefault();

                questionList.Add(question);
            }
            QuestionAndTagModel passedModel = new QuestionAndTagModel();
            passedModel.QuestionList = questionList;

            return View(passedModel);
        }


    }
}