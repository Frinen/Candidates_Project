using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class CandidateSkillService
    {
        static public void Create(CandidatesContext context, int skillID, int candidateID, int month, string level)
        {
            context.Database.EnsureCreated();
            var candidateskill = new CandidateSkill{ SkillID = skillID, CandidateID = candidateID, Month = month, Level = level};
            context.CandidateSkills.Add(candidateskill);
            context.SaveChanges();
        }
        public static void Update(CandidatesContext context, int skillID, int candidateID, int month, string level)
        {
            var candidateskill = new CandidateSkill { SkillID = skillID, CandidateID = candidateID, Month = month, Level = level };
            context.CandidateSkills.Update(candidateskill);
            context.SaveChanges();
            
        }
        public static void Remove(CandidatesContext context, int skillID, int candidateID)
        {
            var candidateSkill = context.CandidateSkills.Find(skillID, candidateID);
            if (candidateSkill != null)
            {
                context.CandidateSkills.Remove(candidateSkill);
                context.SaveChanges();
            }
        }
        public static CandidateSkill Display(CandidatesContext context, int skillID, int candidateID)
        {
            var candidateSkill = context.CandidateSkills.Find(skillID, candidateID);
            return candidateSkill;
            
        }
        public static List<CandidateSkill> Display(CandidatesContext context)
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
