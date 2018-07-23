﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Models.Models
{
    public class CandidateDetailsDTO
    {
        public int ID { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
    }
}