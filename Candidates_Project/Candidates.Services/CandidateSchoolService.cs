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
using Candidates.Responses;

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
        public CandidateSchoolResponse Get(QuerySettings settings)
        {
            var response = new CandidateSchoolResponse();
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.CandidateSchools.Count())
            {
                IEnumerable<CandidateSchool> candidatesSchoolsPage = _context.CandidateSchools.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                var candidatesSchoolsPageDTO = Mapper.Map<IEnumerable<CandidateSchool>, IEnumerable<CandidateSchoolDTO>>(candidatesSchoolsPage);
                response.List = candidatesSchoolsPageDTO;
                response.PageCount = _context.CandidateSchools.Count() / settings.PageSize;
                response.ItemCount = _context.CandidateLanguages.Count();
                response.Message = "Ok";
            }
            else
            {
                response.Message = $" Incorrect page or item count, max item count: { _context.CandidateSchools.Count() }";
                response.ItemCount = _context.CandidateSchools.Count();
            }
            return response;
        }
    }
}
