using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candidates.Models.Models
{
    public class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<CandidateSkill> CandidateSkills { get; set; }
    }
}
