using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candidates.Models.Models
{
    public class CandidateSchool
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
