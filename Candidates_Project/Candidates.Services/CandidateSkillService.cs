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
        public static void Update(CandidatesContext context, int id, CandidateSkill candidateSchool)
        {



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
            if (candidateSkill != null)
                return candidateSkill;
            else
                return null;
        }
    }
}
