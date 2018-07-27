using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Models.DTO
{
    public class CandidateLanguageDTO
    {
        public int LanguageID { get; set; }
        public int CandidateID { get; set; }
        public string Level { get; set; }
    }
}
