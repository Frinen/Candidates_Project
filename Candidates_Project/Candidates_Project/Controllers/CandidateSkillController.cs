using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services;
using Candidates.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Candidates_Project.Controllers
{
    
    public class CandidateSkillController : Controller
    {
        private readonly ICandidateSkillService _service;

        public CandidateSkillController(ICandidateSkillService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/CandidateSkill/skillID&candidateID")]
        [HttpGet]
        public CandidateSkillDTO Get(int skillID, int candidateID)
        {
            return _service.Get(skillID, candidateID);
        }
        [Route("api/CandidateSkill")]
        [HttpGet]
        public IQueryable<CandidateSkillDTO> Get()
        {
            return _service.Get();
        }
        [Route("api/CandidateSkill")]
        [HttpDelete]
        public void Delete(int skillID, int candidateID)
        {
            _service.Remove(skillID, candidateID);
        }
        [Route("api/CandidateSkill")]
        [HttpPut]
        public void Update(int skillID, int candidateID, CandidateSkillShortDTO candidateSkill)
        {
            _service.Update(skillID, candidateID, candidateSkill);
        }
        [Route("api/CandidateSkill")]
        [HttpPost]
        public void Create(CandidateSkillDTO candidateSkill)
        {
            _service.Create(candidateSkill);
        }
    }
}