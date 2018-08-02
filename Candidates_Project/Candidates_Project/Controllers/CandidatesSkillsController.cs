using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Library;
using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services;
using Candidates.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Candidates.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Candidates_Project.Controllers
{
    
    public class CandidatesSkillsController : Controller
    {
        private readonly ICandidateSkillService _service;

        public CandidatesSkillsController(ICandidateSkillService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/CandidatesSkills/skillID&candidateID")]
        [HttpGet]
        public Task<CandidateSkillDTO> GetAsync(int skillID, int candidateID)
        {
            return _service.GetAsync(skillID, candidateID);
        }
        [Route("api/CandidatesSkill")]
        [HttpGet]
        public PageResponse<CandidateSkillDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/CandidatesSkills")]
        [Authorize(Roles = "hr")]
        [HttpDelete]
        public void Delete(int skillID, int candidateID)
        {
            _service.RemoveAsync(skillID, candidateID);
        }
        [Route("api/CandidatesSkills")]
        [HttpPut]
        [Authorize(Roles = "hr")]
        public void Update(CandidateSkillDTO candidateSkill)
        {
            _service.UpdateAsync(candidateSkill);
        }
        [Route("api/CandidatesSkills")]
        [HttpPost]
        [Authorize(Roles = "hr")]
        public void Create(CandidateSkillDTO candidateSkill)
        {
            _service.CreateAsync(candidateSkill);
        }
    }
}