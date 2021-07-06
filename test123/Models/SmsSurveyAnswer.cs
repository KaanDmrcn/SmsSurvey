using System;
using System.Collections.Generic;

#nullable disable

namespace test123.Models
{
    public partial class SmsSurveyAnswer
    {
        public string Id { get; set; }
        public string SmsSurveyId { get; set; }
        public string Answer { get; set; }

        public virtual SmsSurvey SmsSurvey { get; set; }
    }
}
