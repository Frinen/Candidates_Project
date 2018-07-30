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

namespace Candidates.Services
{
    public class CandidateService : ICandidateService
    {
        private CandidatesContext _context;
        public CandidateService(CandidatesContext context)
        {
            _context = context;
           
        }
        public void Create(CandidateDTO candidateDTO)
        {
            _context.Database.EnsureCreated();
            var candidate = Mapper.Map<CandidateDTO, Candidate>(candidateDTO);
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
        }
        public void Update(CandidateDetailsDTO candidateDTO)
        {
            var candidate = Mapper.Map<CandidateDetailsDTO, Candidate>(candidateDTO);
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
            var candidate = _context.Candidates.Find(id);
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
