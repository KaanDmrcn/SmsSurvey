using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test123.Models;

namespace test123.Controllers
{
    public class SmsSurveyAnswerController : Controller
    {
        private readonly SmsSurveyContext _db;
        public SmsSurveyAnswerController(SmsSurveyContext db)
        {
            _db = db;
        }


        public ActionResult Answer()
        {
            var _data = _db.SmsSurveyAnswers;

            return View(_data);
        }

        [HttpGet]
        public ActionResult NewSmsSurveyAnswer()
        {
            return View();
        }


        [HttpPost]
        public ActionResult NewSmsSurveyAnswer(SmsSurveyAnswer p1)
        {
            _db.SmsSurveyAnswers.Add(p1);
            _db.SaveChanges();
            return RedirectToAction("Answer");
        }
        public ActionResult Delete(string Id)
        {
            var survey = _db.SmsSurveyAnswers.Find(Id);
            _db.SmsSurveyAnswers.Remove(survey);
            _db.SaveChanges();
            return RedirectToAction("Answer");
        }
        public ActionResult GetSmsSurveyAnswer(string Id)
        {
            var survey = _db.SmsSurveyAnswers.Find(Id);
            return View("GetSmsSurveyAnswer", survey);
        }
        public ActionResult Update(SmsSurveyAnswer p1)
        {
            var survey = _db.SmsSurveyAnswers.Find(p1.Id);
            survey.Id = p1.Id;
            survey.SmsSurveyId = p1.SmsSurveyId;
            survey.Answer = p1.Answer;
            _db.SaveChanges();
            return RedirectToAction("Answer");

        }

    }
}
