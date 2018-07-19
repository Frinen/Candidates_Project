using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    
    public class SkillService : ISkillService
    {
        CandidatesContext context;
        public SkillService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create(string name)
        {
            context.Database.EnsureCreated();
            var skill = new Skill { Name = name };
            context.Skills.Add(skill);
            context.SaveChanges();
        }
        public void Update(int id, string name)
        {
            var skill = new Skill {ID = id, Name = name };
            context.Skills.Update(skill);
            context.SaveChanges();
        }
        public void Remove(int id)
        {
            var skill = context.Skills.Find(id);
            if (skill != null)
            { 
                context.Skills.Remove(skill);
                context.SaveChanges();
            }
        }
        public Skill Display(int id)
        {
            var skill = context.Skills.Find(id);
            if (skill != null)
                return skill;
            else
                return null;
        }
        public List<Skill> Display()
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
