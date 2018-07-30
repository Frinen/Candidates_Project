using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candidates.Models.Models
{
    public class CandidateSkill : CandidateProperties
    {
        [Required]
        public int SkillID { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public string Level { get; set; }
        public Candidate Candidate { get; set; }
        public Skill Skill { get; set; }
    }
}
