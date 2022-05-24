using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Survey
    {
        public int SurveyId { get; set; }
        public string Year { get; set; } = null!;
        public int Quarter { get; set; }
    }
}
