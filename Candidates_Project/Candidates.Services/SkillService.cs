using Candidates.Library;
using Candidates.Models.Context;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Candidates.Services
{
    
    public class SkillService : ISkillService
    {
        CandidatesContext _context;
        public SkillService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(SkillShortDTO skillDTO)
        {
            _context.Database.EnsureCreated();
            var skill = Mapper.Map<SkillShortDTO, Skill>(skillDTO);
            _context.Skills.Add(skill);
            _context.SaveChanges();
        }
        public void Update(SkillDTO skillDTO)
        {
            var skill = Mapper.Map<SkillDTO, Skill>(skillDTO);
            _context.Skills.Update(skill);
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
            var skill = _context.Skills.Find(id);
            var skillDTO = Mapper.Map<Skill, SkillDTO>(skill);
            return skillDTO;
        }
        public List<SkillDTO> Get(QuerySettings settings)
        {
            var skills = new List<Skill>();
            foreach (var s in _context.Skills)
                skills.Add(s);
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= skills.Count)
            {
                var skillsPage = skills.GetRange((settings.Page - 1) * settings.PageSize, settings.PageSize);
                var skillsPageDTO = Mapper.Map<List<Skill>, List<SkillDTO>>(skillsPage);
                return skillsPageDTO;
            }
            else
            {
                var skillsPageDTO = Mapper.Map<List<Skill>, List<SkillDTO>>(skills);
                return skillsPageDTO;
            }
        }
    }
}
