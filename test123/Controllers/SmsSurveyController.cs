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
    public class SmsSurveyController : Controller
    {
        private readonly SmsSurveyContext _db;
        public SmsSurveyController(SmsSurveyContext db)
        {
            _db = db;
        }

        //public ActionResult GetSmsSurvey()
        //{
        //    var _data = _db.SmsSurveys;
        //    return Ok(_data);
        //}
        public ActionResult SmsSurvey()
        {
            var _data = _db.SmsSurveys;

            return View(_data);
        }

        [HttpGet]
        public ActionResult NewSmsSurvey()
        {
            return View();
        }


        [HttpPost]
        public ActionResult NewSmsSurvey(SmsSurvey p1)
        {
            _db.SmsSurveys.Add(p1);
            _db.SaveChanges();
            return RedirectToAction("SmsSurvey");
        }

        public ActionResult Delete(string Id)
        {
            var survey = _db.SmsSurveys.Find(Id);
            _db.SmsSurveys.Remove(survey);
            _db.SaveChanges();
            return RedirectToAction("SmsSurvey");
        }

        public ActionResult GetSmsSurvey(string Id)
        {
            var survey = _db.SmsSurveys.Find(Id);
            return View("GetSmsSurvey", survey);
        }
        public ActionResult Update(SmsSurvey p1)
        {
            var survey = _db.SmsSurveys.Find(p1.Id);
            survey.StartDate = p1.StartDate;
            //survey.Duration = p1.Duration;
            survey.Question = p1.Question;
            //survey.InsertedBy = p1.InsertedBy;
            //survey.InsertedDate = p1.InsertedDate;
            survey.UpdatedBy = "kaan";
            survey.UpdatedDate = DateTime.Now;
            _db.SaveChanges();
            return RedirectToAction("SmsSurvey");

        }
        public ActionResult Publish(SmsSurvey p1)
        {
            var survey = _db.SmsSurveys.Find(p1.Id);
            survey.Status = "published";
            _db.SaveChanges();
            return RedirectToAction("SmsSurvey");
        }
        public ActionResult TakeItBack(SmsSurvey p1)
        {
            var survey = _db.SmsSurveys.Find(p1.Id);
            survey.Status = "planned";
            _db.SaveChanges();
            return RedirectToAction("SmsSurvey");
        }
        public ActionResult Details([FromRoute] string id)
        {
            var survey = _db.SmsSurveys.Find(id);
            var people = _db.SmsSurveyPeople.Where(ww => ww.SmsSurveyId == id).ToList();
            ViewBag.Peoples = people;
            ViewBag.Survey = survey.Question.ToString();
            return View();
        }

    }
}
