using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Model
{
    public class Candidate_Language
    {
       
        public int LanguageID { get; set; }
       
        public int CandidateID { get; set; }
        public string Level { get; set; }
        public Candidate Candidate { get; set; }
        public Language Language { get; set; }
    }
}
