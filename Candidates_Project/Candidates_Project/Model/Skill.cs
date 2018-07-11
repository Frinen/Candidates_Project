using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Model
{
    public class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Candidate_Skill> Candidate_Skills { get; set; }
    }
}
