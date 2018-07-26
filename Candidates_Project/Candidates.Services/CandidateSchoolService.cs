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
    public class CandidateSchoolService: ICandidateSchoolService
    {
        private CandidatesContext _context;
        public CandidateSchoolService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create( CandidateSchoolDTO candidateSchool)
        {
            _context.Database.EnsureCreated();
            var _candidateschool = new CandidateSchool {HighSchoolID = candidateSchool.HighSchoolID, CandidateID = candidateSchool.CandidateID, From = candidateSchool.From, To = candidateSchool.To, Degree = candidateSchool.Degree};
            _context.CandidateSchools.Add(_candidateschool);
            _context.SaveChanges();
        }
        public void Update(int highSchoolID, int candidateID, CandidateSchoolShortDTO candidateSchool)
        {
            var _candidateSchool = new CandidateSchool { HighSchoolID = highSchoolID, CandidateID = candidateID, From = candidateSchool.From, To = candidateSchool.To, Degree = candidateSchool.Degree};
            _context.CandidateSchools.Update(_candidateSchool);
            _context.SaveChanges();



        }
        public void Remove(int highSchoolID, int candidateID)
        {
            var candidateSchool = _context.CandidateSchools.Find(highSchoolID, candidateID);
            if (candidateSchool != null)
            {
                _context.CandidateSchools.Remove(candidateSchool);
                _context.SaveChanges();
            }
        }
        public CandidateSchoolDTO Get( int highSchoolID, int candidateID)
        {
            
            var candidateSchools = _context.CandidateSchools.Include(c => c.CandidateID).Select(c => new CandidateSchoolDTO()
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
        public IQueryable<CandidateSchoolDTO> GetPage(int page, int pageSize)
        {
            var candidatesSchools = from c in _context.CandidateSchools
                                   select new CandidateSchoolDTO()
                                     {
                                       CandidateID = c.CandidateID,
                                       HighSchoolID = c.HighSchoolID,
                                       Degree = c.Degree,
                                       From = c.From,
                                       To = c.To
                                   };
            var candidatesSchoolsRange = candidatesSchools.Skip((page - 1) * pageSize).Take(pageSize);
            return candidatesSchoolsRange;

        }
    }
}
