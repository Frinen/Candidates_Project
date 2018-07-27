using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candidates.Models.Models
{
    public class HighSchool:Model
    {
        [Required]
        public string Name { get; set; }
        public List<CandidateSchool> CandidateSchool { get; set; }
    }
}
