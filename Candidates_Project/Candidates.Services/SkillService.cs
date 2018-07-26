using Candidates.Library;
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
        CandidatesContext _context;
        public SkillService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(SkillShortDTO skill)
        {
            _context.Database.EnsureCreated();
            var _skill = new Skill { Name = skill.Name };
            _context.Skills.Add(_skill);
            _context.SaveChanges();
        }
        public void Update(int id, SkillShortDTO skill)
        {
            var _skill = new Skill {ID = id, Name = skill.Name };
            _context.Skills.Update(_skill);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill != null)
            { 
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }
        }
        public SkillDTO Get(int id)
        {
            var skill = _context.Skills.Include(c => c.Name).Select(c => new SkillDTO()
            {
                ID = c.ID,
                Name = c.Name
            }).SingleOrDefault(c => c.ID == id);
            return skill;
        }
        public IQueryable<SkillDTO> Get(QuerySettings settings)
        {
            var skills = from c in _context.Skills
                              select new SkillDTO()
                              {
                                  ID = c.ID,
                                  Name = c.Name
                              };
            var skillsRange = skills.Skip((settings.page - 1) * settings.pageSize).Take(settings.pageSize);
            return skillsRange;
        }
    }
}
