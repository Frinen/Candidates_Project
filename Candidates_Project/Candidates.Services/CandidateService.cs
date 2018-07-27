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
using Candidates.Mappers;

namespace Candidates.Services
{
    public class CandidateService : ICandidateService
    {
        private CandidatesContext _context;
        public CandidateService(CandidatesContext context)
        {
            _context = context;
           
        }
        public void Create(CandidateDTO person)
        {
            _context.Database.EnsureCreated();
            var candidate = Mapper.Map<CandidateDTO, Candidate>(person);
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
        }
        public void Update( int id, CandidateDTO person)
        {
            var candidate = CandidateMapper.DtoToModel(person,id);
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
            var candidatesRange = candidates.GetRange((settings.page - 1) * settings.pageSize, settings.pageSize);
            var candidatesRangeDTO = Mapper.Map<List<Candidate>, List<CandidateShortDTO>>(candidatesRange);
            return candidatesRangeDTO;
        }
    }
}
