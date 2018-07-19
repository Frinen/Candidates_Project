using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class CandidateService : ICandidateService
    {
        CandidatesContext context;
        public CandidateService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create( string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            context.Database.EnsureCreated();
            var person = new Candidate { FirstName = firstName, LastName = lastName, BirthDate = DateTime.Parse(birthDate), Sex = sex, PhoneNumber = phoneNumber, Email = email, Skype = skype };
            context.Candidates.Add(person);
            context.SaveChanges();
        }
        public void Update( int id, string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            var candidate = new Candidate {ID = id, BirthDate = DateTime.Parse(birthDate), Email = email, FirstName=firstName, LastName=lastName, PhoneNumber=phoneNumber, Sex=sex, Skype=skype  };
            context.Candidates.Update(candidate);
            context.SaveChanges();
            
        }
        public void Remove( int id)
        {
            var candidate = context.Candidates.Find(id);
            if (candidate != null)
            {
                context.Candidates.Remove(candidate);
                context.SaveChanges();
            }
        }
        public Candidate Display( int id)
        {
            var candidate = context.Candidates.Find(id);
            return candidate;
           
        }
        public List<Candidate> Display()
        {
            List<Candidate> candidates = new List<Candidate>();
            foreach(var candidate  in context.Candidates)
            {
                candidates.Add(candidate);
            }
            return candidates;
           
        }
    }
}
