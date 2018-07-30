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
        public List<CandidateSkillDTO> Get(QuerySettings settings)
        {
            var candidatesSkills = new List<CandidateSkill>();
            foreach (var c in _context.CandidateSkills)
                candidatesSkills.Add(c);
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= candidatesSkills.Count)
            {
                var candidatesSkillsPage = candidatesSkills.GetRange((settings.Page - 1) * settings.PageSize, settings.PageSize);
                var candidatesSkillsPageDTO = Mapper.Map<List<CandidateSkill>, List<CandidateSkillDTO>>(candidatesSkillsPage);
                return candidatesSkillsPageDTO;
            }
            else
            {
                var candidatesSkillsPageDTO = Mapper.Map<List<CandidateSkill>, List<CandidateSkillDTO>>(candidatesSkills);
                return candidatesSkillsPageDTO;
            }
        }
    }
}
