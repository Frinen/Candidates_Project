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
        [Route("api/CandidateSkillController/skillID&candidateID")]
        [HttpGet]
        public CandidateSkillDTO Details(int skillID, int candidateID)
        {
            return service.Display(skillID, candidateID);
        }
        [Route("api/CandidateSkillController")]
        [HttpGet]
        public IQueryable<CandidateSkillDTO> Details()
        {
            return service.Display();
        }
        [Route("api/CandidateSkillController")]
        [HttpDelete]
        public void Delete(int skillID, int candidateID)
        {
            service.Remove(skillID, candidateID);
        }
        [Route("api/CandidateSkillController")]
        [HttpPut]
        public void Update(int skillID, int candidateID, int month, string level)
        {
            service.Update(skillID, candidateID, month, level);
        }
        [Route("api/CandidateSkillController")]
        [HttpPost]
        public void Create(int skillID, int candidateID, int month, string level)
        {
            service.Create(skillID, candidateID, month, level);
        }
    }
}