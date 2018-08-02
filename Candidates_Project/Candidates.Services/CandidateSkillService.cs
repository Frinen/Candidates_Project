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
using System.Threading.Tasks;

namespace Candidates.Services
{
    public class CandidateSkillService : ICandidateSkillService
    {
        CandidatesContext _context;
        public CandidateSkillService(CandidatesContext context)
        {
            _context = context;
        }
        public async void CreateAsync(CandidateSkillDTO candidateSkillDTO)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                await _context.Database.EnsureCreatedAsync();
                var candidateskill = Mapper.Map<CandidateSkillDTO, CandidateSkill>(candidateSkillDTO);
                await _context.CandidateSkills.AddAsync(candidateskill);
                await _context.SaveChangesAsync();
            }
        }
        public async void UpdateAsync(CandidateSkillDTO candidateSkillDTO)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var candidateskill = Mapper.Map<CandidateSkillDTO, CandidateSkill>(candidateSkillDTO);
                _context.CandidateSkills.Update(candidateskill);
                await _context.SaveChangesAsync();
            }
        }
        public async void RemoveAsync(int skillID, int candidateID)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var candidateSkill = await _context.CandidateSkills.FindAsync(skillID, candidateID);
                if (candidateSkill != null)
                {
                    _context.CandidateSkills.Remove(candidateSkill);
                    await _context.SaveChangesAsync();
                }
            }
        }
        public async Task<CandidateSkillDTO> GetAsync( int skillID, int candidateID)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var candidateSkill = await _context.CandidateSkills.FindAsync(skillID, candidateID);
                var candidateSkillDTO = Mapper.Map<CandidateSkill, CandidateSkillDTO>(candidateSkill);
                return candidateSkillDTO;
            }
            else
            {
                return null;
            }
        }
        public PageResponse<CandidateSkillDTO> Get(QuerySettings settings)
        {
            var response = new PageResponse<CandidateSkillDTO>();
            if (_context.Database.EnsureCreated())
            {
                if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.CandidateSkills.Count())
                {
                    IEnumerable<CandidateSkill> candidatesSkillsPage = _context.CandidateSkills.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                    var candidatesSkillsPageDTO = Mapper.Map<IEnumerable<CandidateSkill>, IEnumerable<CandidateSkillDTO>>(candidatesSkillsPage);
                    response.List = candidatesSkillsPageDTO;
                    response.PageCount = _context.CandidateSkills.Count() / settings.PageSize;
                    response.ItemCount = _context.CandidateSkills.Count();
                    // response.Message = "Ok";
                }
                else
                {
                    //response.Message = $" Incorrect page or item count, max item count: { _context.CandidateSkills.Count() }";
                    response.ItemCount = _context.CandidateSkills.Count();
                }
            }
            else
            {
                //response.Message = $" Incorrect page or item count, max item count: { _context.CandidateSkills.Count() }";
                response.ItemCount = _context.CandidateSkills.Count();
            }
            return response;
        }
    }
    
}
