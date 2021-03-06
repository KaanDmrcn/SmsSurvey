using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test123.Models;

namespace test123.Api
{   
    
    [Route("api/[controller]")]
    [ApiController]
    public class SmsSurveysController : ControllerBase
    {
        private readonly SmsSurveyContext _context;

        public SmsSurveysController(SmsSurveyContext context)
        {
            _context = context;
        }

        // GET: api/SmsSurveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmsSurvey>>> GetSmsSurveys()
        {
            return await _context.SmsSurveys.ToListAsync();
        }

        // GET: api/SmsSurveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SmsSurvey>> GetSmsSurvey(int id)
        {
            var smsSurvey = await _context.SmsSurveys.FindAsync(id);

            if (smsSurvey == null)
            {
                return NotFound();
            }

            return smsSurvey;
        }

        // PUT: api/SmsSurveys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmsSurvey(int id, SmsSurvey smsSurvey)
        {
            if (id != smsSurvey.Id)
            {
                return BadRequest();
            }

            _context.Entry(smsSurvey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmsSurveyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SmsSurveys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SmsSurvey>> PostSmsSurvey(SmsSurvey smsSurvey)
        {
            _context.SmsSurveys.Add(smsSurvey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmsSurvey", new { id = smsSurvey.Id }, smsSurvey);
        }

        // DELETE: api/SmsSurveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmsSurvey(int id)
        {
            var smsSurvey = await _context.SmsSurveys.FindAsync(id);
            if (smsSurvey == null)
            {
                return NotFound();
            }

            _context.SmsSurveys.Remove(smsSurvey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmsSurveyExists(int id)
        {
            return _context.SmsSurveys.Any(e => e.Id == id);
        }

       
    }
}
