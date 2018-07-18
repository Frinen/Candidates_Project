using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    
    public class SkillService
    {
        static public void Create(CandidatesContext context, string name)
        {
            context.Database.EnsureCreated();
            var skill = new Skill { Name = name };
            context.Skills.Add(skill);
            context.SaveChanges();
        }
        public static void Update(CandidatesContext context, int id, string name)
        {
            var skill = new Skill {ID = id, Name = name };
            context.Skills.Update(skill);
            context.SaveChanges();
        }
        public static void Remove(CandidatesContext context, int id)
        {
            var skill = context.Skills.Find(id);
            if (skill != null)
            { 
                context.Skills.Remove(skill);
                context.SaveChanges();
            }
        }
        public static Skill Display(CandidatesContext context, int id)
        {
            var skill = context.Skills.Find(id);
            if (skill != null)
                return skill;
            else
                return null;
        }
        public static List<Skill> Display(CandidatesContext context)
        {
            List<Skill> skills= new List<Skill>();
            foreach (var skill in context.Skills)
            {
                skills.Add(skill);
            }
            return skills;
        }
    }
}
