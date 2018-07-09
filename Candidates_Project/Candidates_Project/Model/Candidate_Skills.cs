using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Model
{
    public class Candidate_Skills
    {
        public int SkillsID { get; set; }
        public int CandidateID { get; set; }
        public int Month { get; set; }
        public string Level { get; set; }
    }
}
