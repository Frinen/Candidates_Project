using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Candidates.Library;
using AutoMapper;
using Candidates.Models.DTO;
using System.Threading.Tasks;

namespace Candidates.Services
{
    public class CandidateService : ICandidateService
    {
        private CandidatesContext _context;
        public CandidateService(CandidatesContext context)
        {
            _context = context;
           
        }
        public async void CreateAsync(CandidateDTO candidateDTO)
        {
            await _context.Database.EnsureCreatedAsync();
            var candidate = Mapper.Map<CandidateDTO, Candidate>(candidateDTO);
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }
        public async void UpdateAsync(CandidateDetailsDTO candidateDTO)
        {
            var candidate = Mapper.Map<CandidateDetailsDTO, Candidate>(candidateDTO);
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
            
        }
        public async void RemoveAsync( int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<CandidateDetailsDTO> GetAsync( int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            var candidateDTO = Mapper.Map<Candidate, CandidateDetailsDTO>(candidate);
            return candidateDTO;
        }
        public PageResponse<CandidateShortDTO> Get(QuerySettings settings)
        {
            var response = new PageResponse<CandidateShortDTO>();
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.Candidates.Count())
            {
                IEnumerable<Candidate> candidatesPage = _context.Candidates.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                var candidatesPageDTO = Mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateShortDTO>>(candidatesPage);
                response.List = candidatesPageDTO;
                response.PageCount = _context.Candidates.Count() / settings.PageSize;
                response.ItemCount = _context.Candidates.Count();
               // response.Message = "Ok";
            }
            else
            {
                //response.Message = $" Incorrect page or item count, max item count: { _context.Candidates.Count() }";
                response.ItemCount = _context.Candidates.Count();
            }
            return response;
        }
    }
}
