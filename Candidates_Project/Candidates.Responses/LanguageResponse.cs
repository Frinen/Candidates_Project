using Candidates.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Responses
{
    public class LanguageResponse : Response
    {
        public IEnumerable<LanguageDTO> List { get; set; }
    }
}
