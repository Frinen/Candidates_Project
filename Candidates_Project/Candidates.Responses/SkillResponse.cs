using Candidates.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Responses
{
    public class SkillResponse : Response
    {
        public IEnumerable<SkillDTO> List { get; set; }
    }
}
