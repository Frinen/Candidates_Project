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
        CandidatesContext context;
        public CandidateSkillService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create( int skillID, int candidateID, int month, string level)
        {
            context.Database.EnsureCreated();
            var candidateskill = new CandidateSkill{ SkillID = skillID, CandidateID = candidateID, Month = month, Level = level};
            context.CandidateSkills.Add(candidateskill);
            context.SaveChanges();
        }
        public void Update(int skillID, int candidateID, int month, string level)
        {
            var candidateskill = new CandidateSkill { SkillID = skillID, CandidateID = candidateID, Month = month, Level = level };
            context.CandidateSkills.Update(candidateskill);
            context.SaveChanges();
            
        }
        public void Remove(int skillID, int candidateID)
        {
            var candidateSkill = context.CandidateSkills.Find(skillID, candidateID);
            if (candidateSkill != null)
            {
                context.CandidateSkills.Remove(candidateSkill);
                context.SaveChanges();
            }
        }
        public CandidateSkillDTO Display( int skillID, int candidateID)
        {
            var candidateSkills = context.CandidateSkills.Include(c => c.CandidateID).Select(c => new CandidateSkillDTO()
            {
                CandidateID = c.CandidateID,
                SkillID = c.SkillID,
                Level = c.Level,
                Month = c.Month
            }).Where(c => c.CandidateID == candidateID);
            var candidateSkill = candidateSkills.SingleOrDefault(c => c.SkillID == skillID);
            return candidateSkill;
        }
        public IQueryable<CandidateSkillDTO> Display()
        {
            var candidateSkills = from c in context.CandidateSkills
                                  select new CandidateSkillDTO()
                                   {
                                      CandidateID = c.CandidateID,
                                      SkillID = c.SkillID,
                                      Level = c.Level,
                                      Month = c.Month
                                  };
            return candidateSkills;
        }
    }
}
