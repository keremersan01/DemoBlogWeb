using DemoBlogWeb.Data;
using DemoBlogWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
           
            IEnumerable<Question> questionList = _dbContext.Questions.Include(o => o.Answers).ToList();
            
           
            return View(questionList);

        }

        public IActionResult Question(int? id)
        {
            var obj = _dbContext.Questions.Include(o => o.Answers).SingleOrDefault(u=>u.Id == id);
            return View(obj);
        }

        public IActionResult CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateQuestion(Question obj)
        {
            if (obj.Title == obj.QuestionBody.ToString())
            {
                ModelState.AddModelError("CustomError", "The title should be different from the question body");
            }
            if(ModelState.IsValid)
            {
                _dbContext.Questions.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult CreateAnswer()
        {
            return View();
        }


    }
}