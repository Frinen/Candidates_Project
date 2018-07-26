﻿using Candidates.Library;
using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

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
            var _candidateskill = new CandidateSkill{ SkillID = candidateSkill.SkillID, CandidateID = candidateSkill.CandidateID, Month = candidateSkill.Month, Level = candidateSkill.Level};
            _context.CandidateSkills.Add(_candidateskill);
            _context.SaveChanges();
        }
        public void Update(int skillID, int candidateID, CandidateSkillShortDTO candidateSkill)
        {
            var _candidateskill = new CandidateSkill { SkillID = skillID, CandidateID = candidateID, Month = candidateSkill.Month, Level = candidateSkill.Level };
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
            var candidateSkills = _context.CandidateSkills.Include(c => c.CandidateID).Select(c => new CandidateSkillDTO()
            {
                CandidateID = c.CandidateID,
                SkillID = c.SkillID,
                Level = c.Level,
                Month = c.Month
            }).Where(c => c.CandidateID == candidateID);
            var candidateSkill = candidateSkills.SingleOrDefault(c => c.SkillID == skillID);
            return candidateSkill;
        }
        public IQueryable<CandidateSkillDTO> Get(QuerySettings settings)
        {
            var candidatesSkills = from c in _context.CandidateSkills
                                  select new CandidateSkillDTO()
                                   {
                                      CandidateID = c.CandidateID,
                                      SkillID = c.SkillID,
                                      Level = c.Level,
                                      Month = c.Month
                                  };
            var candidatesSkillsRange = candidatesSkills.Skip((settings.page - 1) * settings.pageSize).Take(settings.pageSize);
            return candidatesSkillsRange;
        }
    }
}
