using Candidates.Library;
using Candidates.Models.Context;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using AutoMapper;
using Candidates.Responses;

namespace Candidates.Services
{
    public class CandidateSkillService : ICandidateSkillService
    {
        CandidatesContext _context;
        public CandidateSkillService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(CandidateSkillDTO candidateSkillDTO)
        {
            _context.Database.EnsureCreated();
            var candidateskill = Mapper.Map<CandidateSkillDTO, CandidateSkill>(candidateSkillDTO);
            _context.CandidateSkills.Add(candidateskill);
            _context.SaveChanges();
        }
        public void Update(CandidateSkillDTO candidateSkillDTO)
        {
            var candidateskill = Mapper.Map<CandidateSkillDTO, CandidateSkill>(candidateSkillDTO);
            _context.CandidateSkills.Update(candidateskill);
            _context.SaveChanges();
        }
        public void Remove(int skillID, int candidateID)
        {
            var candidateSkill = _context.CandidateSkills.Find(skillID, candidateID);
            if (candidateSkill != null)
            {
                _context.CandidateSkills.Remove(candidateSkill);
                _context.SaveChanges();
            }
        }
        public CandidateSkillDTO Get( int skillID, int candidateID)
        {
            var candidateSkill = _context.CandidateSkills.Find(skillID, candidateID);
            var candidateSkillDTO = Mapper.Map<CandidateSkill, CandidateSkillDTO>(candidateSkill);
            return candidateSkillDTO;
        }
        public CandidateSkillResponse Get(QuerySettings settings)
        {
            var response = new CandidateSkillResponse();
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.CandidateSkills.Count())
            {
                IEnumerable<CandidateSkill> candidatesSkillsPage = _context.CandidateSkills.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                var candidatesSkillsPageDTO = Mapper.Map<IEnumerable<CandidateSkill>, IEnumerable<CandidateSkillDTO>>(candidatesSkillsPage);
                response.List = candidatesSkillsPageDTO;
                response.PageCount = _context.CandidateSkills.Count() / settings.PageSize;
                response.ItemCount = _context.CandidateSkills.Count();
                response.Message = "Ok";
            }
            else
            {
                response.Message = $" Incorrect page or item count, max item count: { _context.CandidateSkills.Count() }";
                response.ItemCount = _context.CandidateSkills.Count();
            }
            return response;
        }
    }
    
}
