using Candidates.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Responses
{
    public class CandidateResponse : Response
    {
        public IEnumerable<CandidateShortDTO> List { get; set; }
    }
}
