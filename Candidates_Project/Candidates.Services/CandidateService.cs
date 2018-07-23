﻿using Candidates.Models.Context;
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
        public CandidateDetailsDTO Display( int id)
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
        public IQueryable<CandidateDTO> Display()
        {
            var candidates = from c in context.Candidates
                        select new CandidateDTO()
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
