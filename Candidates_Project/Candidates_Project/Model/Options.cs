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
        public bool CanWorkRemotly { get; set; }
        public bool CanRelocate{ get; set; }
        public bool CanWorkInTheOffice { get; set; }
        public Candidate Candidate { get; set; }
    }
}
