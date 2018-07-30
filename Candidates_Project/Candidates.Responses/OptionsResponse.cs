using Candidates.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Responses
{
    public class OptionsResponse : Response
    {
        public IEnumerable<OptionsDTO> List { get; set; }
    }
}
