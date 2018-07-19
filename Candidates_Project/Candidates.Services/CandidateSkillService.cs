using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
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
        public CandidateSkill Display( int skillID, int candidateID)
        {
            var candidateSkill = context.CandidateSkills.Find(skillID, candidateID);
            return candidateSkill;
            
        }
        public List<CandidateSkill> Display()
        {
            List<CandidateSkill> candidateSkills = new List<CandidateSkill>();
            foreach (var candidateSkill in context.CandidateSkills)
            {
                candidateSkills.Add(candidateSkill);
            }
            return candidateSkills;
        }
    }
}
