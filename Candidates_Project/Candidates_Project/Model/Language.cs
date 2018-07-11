using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Model
{
    public class Language
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<CandidateLanguage> CandidateLanguages { get; set; }
}
}
