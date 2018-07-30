using Candidates.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Responses
{
    public class HighSchoolResponse : Response
    {
        public IEnumerable<HighSchoolDTO> List { get; set; }
    }
}
