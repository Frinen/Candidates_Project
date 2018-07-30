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
        public CandidateSkillDTO Get(int skillID, int candidateID)
        {
            return _service.Get(skillID, candidateID);
        }
        [Route("api/CandidatesSkill")]
        [HttpGet]
        public List<CandidateSkillDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/CandidatesSkills")]
        [HttpDelete]
        public void Delete(int skillID, int candidateID)
        {
            _service.Remove(skillID, candidateID);
        }
        [Route("api/CandidatesSkills")]
        [HttpPut]
        public void Update(CandidateSkillDTO candidateSkill)
        {
            _service.Update(candidateSkill);
        }
        [Route("api/CandidatesSkills")]
        [HttpPost]
        public void Create(CandidateSkillDTO candidateSkill)
        {
            _service.Create(candidateSkill);
        }
    }
}