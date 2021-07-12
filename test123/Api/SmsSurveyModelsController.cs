using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test123.Model;
using test123.Models;

namespace test123.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsSurveyModelsController : ControllerBase
    {
        private readonly SmsSurveyContext _context;
        private readonly IMapper _mapper;

        public SmsSurveyModelsController(IMapper mapper, SmsSurveyContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        //public SmsSurveyModelsController(SmsSurveyContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        public IActionResult GetUser()
        {            
            var _data = _context.SmsSurveys;           
            return Ok(_mapper.ProjectTo<SmsSurveyModel>(_data));
        }
        
    }
}
