using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Model
{
    public class HighSchool
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<CandidateSchool> Candidate_School { get; set; }
    }
}
