using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Model
{
    public class Candidate
    {
       
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
       public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public Options Options { get; set; }
        public List<Candidate_Skills> Candidate_Skills { get; set; }
        public List<Candidate_School> Candidate_School { get; set; }
        public List<Candidate_Language> Candidate_Language { get; set; }
    }
}
