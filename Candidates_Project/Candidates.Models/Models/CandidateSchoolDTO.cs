using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Models.Models
{
    public class CandidateSchoolDTO
    {
        public int HighSchoolID { get; set; }
        public int CandidateID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Degree { get; set; }
    }
}
