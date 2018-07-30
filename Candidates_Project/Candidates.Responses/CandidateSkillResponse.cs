using Candidates.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Responses
{
    public class CandidateSkillResponse : Response
    {
        public IEnumerable<CandidateSkillDTO> List { get; set; }
    }
}
