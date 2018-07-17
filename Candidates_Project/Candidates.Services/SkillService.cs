using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    
    public class SkillService
    {
        static public void AddSkill(CandidatesContext context, string name)
        {
            context.Database.EnsureCreated();
            var skill = new Skill { Name = name };
            context.Skills.Add(skill);
            context.SaveChanges();
        }
        public static void ChangeSkill(CandidatesContext context, int id, Skill skill)
        {



        }
        public static void DeleteSkill(CandidatesContext context, int id)
        {
            var skill = context.Skills.Find(id);
            if (skill != null)
            { 
                context.Skills.Remove(skill);
                context.SaveChanges();
            }
        }
        public static Skill VievSkill(CandidatesContext context, int id)
        {
            var skill = context.Skills.Find(id);
            if (skill != null)
                return skill;
            else
                return null;
        }
    }
}
