using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Models.Models
{
    public class OptionsDTO
    {
        public int CandidateID { get; set; }
        public bool CanWorkRemotly { get; set; }
        public bool CanRelocate { get; set; }
        public bool CanWorkInTheOffice { get; set; }
    }
}
