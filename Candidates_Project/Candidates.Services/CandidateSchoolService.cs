using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Candidates.Library;
using Candidates.Models.DTO;
using AutoMapper;

namespace Candidates.Services
{
    public class CandidateSchoolService: ICandidateSchoolService
    {
        private CandidatesContext _context;
        public CandidateSchoolService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create( CandidateSchoolDTO candidateSchoolDTO)
        {
            _context.Database.EnsureCreated();
            var candidateschool = Mapper.Map<CandidateSchoolDTO, CandidateSchool>(candidateSchoolDTO);
            _context.CandidateSchools.Add(candidateschool);
            _context.SaveChanges();
        }
        public void Update(CandidateSchoolDTO candidateSchoolDTO)
        {
            var candidateSchool = Mapper.Map<CandidateSchoolDTO, CandidateSchool>(candidateSchoolDTO);
            _context.CandidateSchools.Update(candidateSchool);
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
            var candidateSchool = _context.CandidateSchools.Find(highSchoolID,candidateID);
            var candidateSchoolDTO = Mapper.Map<CandidateSchool, CandidateSchoolDTO>(candidateSchool);
            return candidateSchoolDTO;
        }
        public List<CandidateSchoolDTO> Get(QuerySettings settings)
        {
            var candidatesSchools = new List<CandidateSchool>();
            foreach (var c in _context.CandidateSchools)
                candidatesSchools.Add(c);
            var candidatesSchoolsPage = candidatesSchools.GetRange((settings.page - 1) * settings.pageSize, settings.pageSize);
            var candidatesSchoolsPageDTO = Mapper.Map<List<CandidateSchool>, List<CandidateSchoolDTO>>(candidatesSchoolsPage);
            return candidatesSchoolsPageDTO;
        }
    }
}
