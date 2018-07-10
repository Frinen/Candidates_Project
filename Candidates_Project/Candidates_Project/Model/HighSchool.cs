using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Model
{
    public class HighSchool
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Candidate_School> Candidate_School { get; set; }
    }
}
