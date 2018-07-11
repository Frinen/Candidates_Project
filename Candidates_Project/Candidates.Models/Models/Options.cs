using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candidates.Models.Models
{
    public class Options
    {
        [Key]
        public int CandidateID { get; set; }
        [Required]
        public bool CanWorkRemotly { get; set; }
        [Required]
        public bool CanRelocate{ get; set; }
        [Required]
        public bool CanWorkInTheOffice { get; set; }
        public Candidate Candidate { get; set; }
    }
}
