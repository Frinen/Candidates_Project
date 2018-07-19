using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class CandidateSchoolService: ICandidateSchoolService
    {
        CandidatesContext context;
        public CandidateSchoolService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create( int highSchoolID, int candidateID, string from, string to, string degree)
        {
            context.Database.EnsureCreated();
            var candidateschool = new CandidateSchool {HighSchoolID = highSchoolID, CandidateID = candidateID, From = DateTime.Parse(from), To = DateTime.Parse(to), Degree = degree };
            context.CandidateSchools.Add(candidateschool);
            context.SaveChanges();
        }
        public void Update(int highSchoolID, int candidateID, string from, string to, string degree)
        {
            var candidateSchool = new CandidateSchool { HighSchoolID = highSchoolID, CandidateID = candidateID, From = DateTime.Parse(from), To = DateTime.Parse(to), Degree = degree };
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
        public CandidateSchool Display( int highSchoolID, int candidateID)
        {
            var candidateSchool = context.CandidateSchools.Find(highSchoolID, candidateID);
            return candidateSchool;
            
        }
        public List<CandidateSchool> Display()
        {
            List<CandidateSchool> candidateSchools = new List<CandidateSchool>();
            foreach (var candidateSchool in context.CandidateSchools)
            {
                candidateSchools.Add(candidateSchool);
            }
            return candidateSchools;
        }
    }
}
