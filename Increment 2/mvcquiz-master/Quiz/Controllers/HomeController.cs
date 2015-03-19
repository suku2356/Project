using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            QuestionsList questions = new QuestionsList();

            return View(questions);
        }

        [HttpPost]
        public ActionResult Index(List<QuizModel> questions)
        {
            var truescore =  questions.Count(x => x.Anwser.HasValue && x.Anwser.Value);
            var falsescore = questions.Count(x => x.Anwser.HasValue && !x.Anwser.Value);

            if (truescore >= 8)
            {
                ViewBag.Grade = "I";
            }
            if (falsescore >= 8)
            {
                ViewBag.Grade = "E";
            }


            if ((truescore >= 6 && truescore < 8) || (falsescore >= 6 && falsescore < 8))
            {
                ViewBag.Grade = "E/I";
            }

            return View("About");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}