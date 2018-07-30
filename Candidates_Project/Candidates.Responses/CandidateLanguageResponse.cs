using Candidates.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Responses
{
    public class CandidateLanguageResponse : Response
    {
        public IEnumerable<CandidateLanguageDTO> List { get; set; }
    }
}
