using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Candidates_Project.Model
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
