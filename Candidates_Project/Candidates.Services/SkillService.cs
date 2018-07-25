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
    
    public class SkillService : ISkillService
    {
        CandidatesContext context;
        public SkillService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create(SkillShortDTO _skill)
        {
            context.Database.EnsureCreated();
            var skill = new Skill { Name = _skill.Name };
            context.Skills.Add(skill);
            context.SaveChanges();
        }
        public void Update(int id, SkillShortDTO _skill)
        {
            var skill = new Skill {ID = id, Name = _skill.Name };
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
        public SkillDTO Get(int id)
        {
            var skill = context.Skills.Include(c => c.Name).Select(c => new SkillDTO()
            {
                ID = c.ID,
                Name = c.Name
            }).SingleOrDefault(c => c.ID == id);
            return skill;
        }
        public IQueryable<SkillDTO> Get()
        {
            var skills = from c in context.Skills
                              select new SkillDTO()
                              {
                                  ID = c.ID,
                                  Name = c.Name
                              };
            return skills;
        }
    }
}
