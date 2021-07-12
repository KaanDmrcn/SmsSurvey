using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using test123.Models;
using test123.Model;

namespace test123.Map
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SmsSurvey, SmsSurveyModel>();
        }
        
    }
}
