using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candidates.Models.Models
{
    public class CandidateProperties
    {
        [Required]
        public int CandidateID { get; set; }
    }
}
