﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candidates.Models.Models
{
    public class CandidateLanguage : CandidateProperties
    {
        [Required]
        public int LanguageID { get; set; }
        [Required]
        public string Level { get; set; }
        public Candidate Candidate { get; set; }
        public Language Language { get; set; }
    }
}
