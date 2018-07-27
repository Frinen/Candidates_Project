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
using Candidates.Mappers;

namespace Candidates.Services
{
    public class CandidateSkillService : ICandidateSkillService
    {
        CandidatesContext _context;
        public CandidateSkillService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(CandidateSkillDTO candidateSkill)
        {
            _context.Database.EnsureCreated();
            var _candidateskill = Mapper.Map<CandidateSkillDTO, CandidateSkill>(candidateSkill);
            _context.CandidateSkills.Add(_candidateskill);
            _context.SaveChanges();
        }
        public void Update(int skillID, int candidateID, CandidateSkillShortDTO candidateSkill)
        {
            var _candidateskill = CandidateSkillMapper.DtoToModel(skillID, candidateID, candidateSkill);
            _context.CandidateSkills.Update(_candidateskill);
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
        public List<CandidateSkillDTO> Get(QuerySettings settings)
        {
            var candidatesSkills = new List<CandidateSkill>();
            foreach (var c in _context.CandidateSkills)
                candidatesSkills.Add(c);
            var candidatesSkillsRange = candidatesSkills.GetRange((settings.page - 1) * settings.pageSize, settings.pageSize);
            var candidatesSkillsDTO = Mapper.Map<List<CandidateSkill>, List<CandidateSkillDTO>>(candidatesSkillsRange);
            return candidatesSkillsDTO;
        }
    }
}
