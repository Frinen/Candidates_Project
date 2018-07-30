using Candidates.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Responses
{
    public class CandidateSchoolResponse : Response
    {
        public IEnumerable<CandidateSchoolDTO> List { get; set; }
    }
}
