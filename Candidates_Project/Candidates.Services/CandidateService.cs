using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;
namespace Candidates.Services
{
    public class CandidateService : ICandidateService
    {
        CandidatesContext context;
        public CandidateService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create(CandidateDTO person)
        {
            context.Database.EnsureCreated();
            var candidate = new Candidate { FirstName = person.FirstName, LastName = person.LastName, PhoneNumber = person.PhoneNumber, Sex = person.Sex, Skype = person.Skype, BirthDate = person.BirthDate, Email = person.Email };
            context.Candidates.Add(candidate);
            context.SaveChanges();
        }
        public void Update( int id, CandidateDTO person)
        {
            var candidate = new Candidate {ID = id, FirstName = person.FirstName, LastName = person.LastName, PhoneNumber = person.PhoneNumber, Sex = person.Sex, Skype = person.Skype, BirthDate = person.BirthDate, Email = person.Email };
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
        public CandidateDetailsDTO Get( int id)
        {
            var candidate = context.Candidates.Include(c => c.LastName).Select(c => new CandidateDetailsDTO()
            {
                ID = c.ID,
                FirstName = c.LastName,
                LastName = c.LastName,
                BirthDate = c.BirthDate,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Sex = c.Sex,
                Skype = c.Skype
            }).SingleOrDefault(c => c.ID == id);
             return candidate;
        }
        public IQueryable<CandidateShortDTO> Get()
        {
            var candidates = from c in context.Candidates
                        select new CandidateShortDTO()
                        {
                            ID = c.ID,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            BirthDate = c.BirthDate
                        };

            return candidates;

        }
    }
}
