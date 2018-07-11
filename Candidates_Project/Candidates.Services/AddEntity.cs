using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class AddEntity
    {
        static public void AddCandidate(CandidatesContext context, string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            context.Database.EnsureCreated();
            var person = new Candidate { FirstName = firstName, LastName = lastName, BirthDate = DateTime.Parse(birthDate), Sex = sex, PhoneNumber = phoneNumber, Email = email, Skype = skype };
            context.Candidates.Add(person);
            context.SaveChanges();
        }
    }
}
