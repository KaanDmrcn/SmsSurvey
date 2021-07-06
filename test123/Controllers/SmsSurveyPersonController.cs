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
    public class SmsSurveyPersonController : Controller
    {
        private readonly SmsSurveyContext _db;
        public SmsSurveyPersonController(SmsSurveyContext db)
        {
            _db = db;
        }


        public ActionResult Person()
        {
            var _data = _db.SmsSurveyPeople;

            return View(_data);
        }

        [HttpGet]
        public ActionResult NewSmsSurveyPerson()
        {
            return View();
        }


        [HttpPost]
        public ActionResult NewSmsSurveyPerson(SmsSurveyPerson p1)
        {
            string guid = Guid.NewGuid().ToString();
            p1.Id = guid;
            _db.SmsSurveyPeople.Add(p1);
            _db.SaveChanges();
            return RedirectToAction("Person");
        }
        public ActionResult Delete(string Id)
        {
            var survey = _db.SmsSurveyPeople.Find(Id);
            _db.SmsSurveyPeople.Remove(survey);
            _db.SaveChanges();
            return RedirectToAction("Person");
        }
        public ActionResult GetSmsSurveyPerson(string Id)
        {
            var survey = _db.SmsSurveyPeople.Find(Id);
            return View("GetSmsSurveyPerson", survey);
        }
        public ActionResult Update(SmsSurveyPerson p1)
        {
            var survey = _db.SmsSurveyPeople.Find(p1.Id);
            survey.Id = p1.Id;
            survey.SmsSurveyId = p1.SmsSurveyId;
            survey.Name = p1.Name;
            survey.PhoneNumber = p1.PhoneNumber;
            survey.Answer = p1.Answer;
            _db.SaveChanges();
            return RedirectToAction("Person");

        }
        


    }
}
