using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Model
{
    public class CandidateSkill
    {
        public int SkillID { get; set; }
        public int CandidateID { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public string Level { get; set; }
        public Candidate Candidate { get; set; }
        public Skill Skill { get; set; }
    }
}
