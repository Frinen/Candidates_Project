using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;
using Candidates.Library;

namespace Candidates.Services
{
    public class CandidateService : ICandidateService
    {
        private CandidatesContext _context;
        public CandidateService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(CandidateDTO person)
        {
            _context.Database.EnsureCreated();
            var candidate = new Candidate { FirstName = person.FirstName, LastName = person.LastName, PhoneNumber = person.PhoneNumber, Sex = person.Sex, Skype = person.Skype, BirthDate = person.BirthDate, Email = person.Email };
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
        }
        public void Update( int id, CandidateDTO person)
        {
            var candidate = new Candidate {ID = id, FirstName = person.FirstName, LastName = person.LastName, PhoneNumber = person.PhoneNumber, Sex = person.Sex, Skype = person.Skype, BirthDate = person.BirthDate, Email = person.Email };
            _context.Candidates.Update(candidate);
            _context.SaveChanges();
            
        }
        public void Remove( int id)
        {
            var candidate = _context.Candidates.Find(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                _context.SaveChanges();
            }
        }
        public CandidateDetailsDTO Get( int id)
        {
            var candidate = _context.Candidates.Include(c => c.LastName).Select(c => new CandidateDetailsDTO()
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
        public IQueryable<CandidateShortDTO> Get(QuerySettings settings)
        {
            var candidates = from c in _context.Candidates
                        select new CandidateShortDTO()
                        {
                            ID = c.ID,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            BirthDate = c.BirthDate
                        };
            var candidatesRange = candidates.Skip((settings.page - 1) * settings.pageSize).Take(settings.pageSize);
            return candidatesRange;

        }
    }
}
