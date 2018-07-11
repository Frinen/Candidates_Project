﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Model
{
    public class Candidate_School
    {
        public int HighSchoolID { get; set; }
        public int CandidateID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime From { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime To { get; set; }
        [Required]
        public string Degree { get; set; }
        public Candidate Candidate { get; set; }
        public HighSchool HighSchool { get; set; }
    }
}
