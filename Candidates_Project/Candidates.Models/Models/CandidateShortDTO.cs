using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Models.Models
{
    public class CandidateShortDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
