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
    public class CandidateSchoolService: ICandidateSchoolService
    {
        CandidatesContext context;
        public CandidateSchoolService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create( CandidateSchoolDTO _candidateSchool)
        {
            context.Database.EnsureCreated();
            var candidateschool = new CandidateSchool {HighSchoolID = _candidateSchool.HighSchoolID, CandidateID = _candidateSchool.CandidateID, From = _candidateSchool.From, To = _candidateSchool.To, Degree = _candidateSchool.Degree};
            context.CandidateSchools.Add(candidateschool);
            context.SaveChanges();
        }
        public void Update(int highSchoolID, int candidateID, CandidateSchoolShortDTO _candidateSchool)
        {
            var candidateSchool = new CandidateSchool { HighSchoolID = highSchoolID, CandidateID = candidateID, From = _candidateSchool.From, To = _candidateSchool.To, Degree = _candidateSchool.Degree};
            context.CandidateSchools.Update(candidateSchool);
            context.SaveChanges();



        }
        public void Remove(int highSchoolID, int candidateID)
        {
            var candidateSchool = context.CandidateSchools.Find(highSchoolID, candidateID);
            if (candidateSchool != null)
            {
                context.CandidateSchools.Remove(candidateSchool);
                context.SaveChanges();
            }
        }
        public CandidateSchoolDTO Get( int highSchoolID, int candidateID)
        {
            
            var candidateSchools = context.CandidateSchools.Include(c => c.CandidateID).Select(c => new CandidateSchoolDTO()
            {
                CandidateID = c.CandidateID,
                HighSchoolID = c.HighSchoolID,
                Degree = c.Degree,
                From = c.From,
                To = c.To
            }).Where(c => c.HighSchoolID == highSchoolID);
            var candidateSchool = candidateSchools.SingleOrDefault(c => c.HighSchoolID == highSchoolID);
            return candidateSchool;

        }
        public IQueryable<CandidateSchoolDTO> Get()
        {
            var candidateSchools = from c in context.CandidateSchools
                                   select new CandidateSchoolDTO()
                                     {
                                       CandidateID = c.CandidateID,
                                       HighSchoolID = c.HighSchoolID,
                                       Degree = c.Degree,
                                       From = c.From,
                                       To = c.To
                                   };
            return candidateSchools;
        }
    }
}
