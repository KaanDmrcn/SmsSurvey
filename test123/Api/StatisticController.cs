using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test123.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test123.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {

        private readonly SmsSurveyContext _context;

        public StatisticController(SmsSurveyContext context)
        {
            _context = context;
        }

        // GET: api/<StatisticController>
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var people = _context.SmsSurveyPeople.Where(ww => ww.SmsSurveyId == id).ToList();
            
            var count = (from num in people
                           select num).Count();
            return Ok(count);
        }

        // GET: api/<StatisticController>
        [HttpGet("{GetTemp}/{id}")]
        public IActionResult GetTemp([FromRoute] int id)
        {
            var people = _context.SmsSurveyPeople.Where(ww => ww.SmsSurveyId == id).ToList();
          
            var temp = people.GroupBy(p => p.Answer)
                                .Select(g => new
                                {
                                  label = g.Key,
                                  value = g.Count().ToString()
                                }).ToList();

            return Ok(temp);
        }

    }
}
