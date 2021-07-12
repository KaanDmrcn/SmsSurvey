using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test123.Model
{
    public class SmsSurveyModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Question { get; set; }
        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public string Status { get; set; }
    }
}
