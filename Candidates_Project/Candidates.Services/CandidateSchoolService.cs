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
using System.Threading.Tasks;

namespace Candidates.Services
{
    public class CandidateSchoolService: ICandidateSchoolService
    {
        private CandidatesContext _context;
        public CandidateSchoolService(CandidatesContext context)
        {
            _context = context;
        }
        public async void CreateAsync( CandidateSchoolDTO candidateSchoolDTO)
        {
            await _context.Database.EnsureCreatedAsync();
            var candidateschool = Mapper.Map<CandidateSchoolDTO, CandidateSchool>(candidateSchoolDTO);
            await _context.CandidateSchools.AddAsync(candidateschool);
            await _context.SaveChangesAsync();
        }
        public async void UpdateAsync(CandidateSchoolDTO candidateSchoolDTO)
        {
            var candidateSchool = Mapper.Map<CandidateSchoolDTO, CandidateSchool>(candidateSchoolDTO);
            _context.CandidateSchools.Update(candidateSchool);
            await _context.SaveChangesAsync();
        }
        public async void RemoveAsync(int highSchoolID, int candidateID)
        {
            var candidateSchool = await _context.CandidateSchools.FindAsync(highSchoolID, candidateID);
            if (candidateSchool != null)
            {
                _context.CandidateSchools.Remove(candidateSchool);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<CandidateSchoolDTO> GetAsync( int highSchoolID, int candidateID)
        {
            var candidateSchool = await _context.CandidateSchools.FindAsync(highSchoolID,candidateID);
            var candidateSchoolDTO = Mapper.Map<CandidateSchool, CandidateSchoolDTO>(candidateSchool);
            return candidateSchoolDTO;
        }
        public PageResponse<CandidateSchoolDTO> Get(QuerySettings settings)
        {
            var response = new PageResponse<CandidateSchoolDTO>();
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.CandidateSchools.Count())
            {
                IEnumerable<CandidateSchool> candidatesSchoolsPage = _context.CandidateSchools.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                var candidatesSchoolsPageDTO = Mapper.Map<IEnumerable<CandidateSchool>, IEnumerable<CandidateSchoolDTO>>(candidatesSchoolsPage);
                response.List = candidatesSchoolsPageDTO;
                response.PageCount = _context.CandidateSchools.Count() / settings.PageSize;
                response.ItemCount = _context.CandidateLanguages.Count();
                //response.Message = "Ok";
            }
            else
            {
                //response.Message = $" Incorrect page or item count, max item count: { _context.CandidateSchools.Count() }";
                response.ItemCount = _context.CandidateSchools.Count();
            }
            return response;
        }
    }
}
