using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Model
{
    public class Candidate_School
    {
        public int HighSchoolID { get; set; }
        public int CandidatesID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Degree { get; set; }

    }
}
