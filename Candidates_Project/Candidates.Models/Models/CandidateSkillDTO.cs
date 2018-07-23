using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Models.Models
{
    public class CandidateSkillDTO
    {
        public int SkillID { get; set; }
        public int CandidateID { get; set; }
        public int Month { get; set; }
        public string Level { get; set; }
    }
}
