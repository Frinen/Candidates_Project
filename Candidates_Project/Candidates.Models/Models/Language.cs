using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candidates.Models.Models
{ 
    public class Language:Model
    {
        [Required]
        public string Name { get; set; }
        public List<CandidateLanguage> CandidateLanguages { get; set; }
    }
}
