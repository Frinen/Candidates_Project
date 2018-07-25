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
        private readonly ICandidateSkillService service;

        public CandidateSkillController(ICandidateSkillService _service)
        {
            service = _service;
        }

        // GET: Default/Details/5
        [Route("api/CandidateSkill/skillID&candidateID")]
        [HttpGet]
        public CandidateSkillDTO Get(int skillID, int candidateID)
        {
            return service.Get(skillID, candidateID);
        }
        [Route("api/CandidateSkill")]
        [HttpGet]
        public IQueryable<CandidateSkillDTO> Get()
        {
            return service.Get();
        }
        [Route("api/CandidateSkill")]
        [HttpDelete]
        public void Delete(int skillID, int candidateID)
        {
            service.Remove(skillID, candidateID);
        }
        [Route("api/CandidateSkill")]
        [HttpPut]
        public void Update(int skillID, int candidateID, CandidateSkillShortDTO candidateSkill)
        {
            service.Update(skillID, candidateID, candidateSkill);
        }
        [Route("api/CandidateSkill")]
        [HttpPost]
        public void Create(CandidateSkillDTO candidateSkill)
        {
            service.Create(candidateSkill);
        }
    }
}