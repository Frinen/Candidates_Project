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
        public PageResponse<SkillDTO> Get(QuerySettings settings)
        {
            var response = new PageResponse<SkillDTO>();
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.Skills.Count())
            {
                IEnumerable<Skill> skillsPage = _context.Skills.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                var skillsPageDTO = Mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDTO>>(skillsPage);
                response.List = skillsPageDTO;
                response.PageCount = _context.Skills.Count() / settings.PageSize;
                response.ItemCount = _context.Skills.Count();
               // response.Message = "Ok";
            }
            else
            {
               // response.Message = $" Incorrect page or item count, max item count: { _context.Skills.Count() }";
                response.ItemCount = _context.Skills.Count();
            }
            return response;
        }
    }
}
