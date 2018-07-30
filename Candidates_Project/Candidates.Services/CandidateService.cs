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
        public List<CandidateShortDTO> Get(QuerySettings settings)
        {
            var candidates= new List<Candidate>();
            foreach (var c in _context.Candidates)
                candidates.Add(c);
            var candidatesPage = candidates.GetRange((settings.page - 1) * settings.pageSize, settings.pageSize);
            var candidatesPageDTO = Mapper.Map<List<Candidate>, List<CandidateShortDTO>>(candidatesPage);
            return candidatesPageDTO;
        }
    }
}
