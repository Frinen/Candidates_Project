using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Candidates.Models.Models
{
    public class Candidate : Model
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string Skype { get; set; }
        public Options Options { get; set; }
        public List<CandidateSkill> CandidateSkills { get; set; }
        public List<CandidateSchool> CandidateSchools { get; set; }
        public List<CandidateLanguage> CandidateLanguages { get; set; }
    }
}
