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
using Candidates.Mappers;

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
            var _skill = Mapper.Map<SkillShortDTO, Skill>(skill);
            _context.Skills.Add(_skill);
            _context.SaveChanges();
        }
        public void Update(int id, SkillShortDTO skill)
        {
            var _skill = SkillMapper.DtoToModel(id, skill);
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
            var skill = _context.Skills.Find(id);
            var skillDTO = Mapper.Map<Skill, SkillDTO>(skill);
            return skillDTO;
        }
        public List<SkillDTO> Get(QuerySettings settings)
        {
            var skills = new List<Skill>();
            foreach (var s in _context.Skills)
                skills.Add(s);
            var skillsRange = skills.GetRange((settings.page - 1) * settings.pageSize, settings.pageSize);
            var skillsDTO = Mapper.Map<List<Skill>, List<SkillDTO>>(skillsRange);
            return skillsDTO;
        }
    }
}
