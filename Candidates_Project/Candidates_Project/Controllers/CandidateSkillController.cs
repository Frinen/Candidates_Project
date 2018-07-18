using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services;
using Microsoft.AspNetCore.Mvc;

namespace Candidates_Project.Controllers
{
    
    public class CandidateSkillController : Controller
    {
        private readonly CandidatesContext context;

        public CandidateSkillController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [Route("api/CandidateSkillController/skillID&candidateID")]
        [HttpGet]
        public CandidateSkill Details(int skillID, int candidateID)
        {
            return CandidateSkillService.Display(context, skillID, candidateID);
        }
        [Route("api/CandidateSkillController")]
        [HttpGet]
        public List<CandidateSkill> Details()
        {
            return CandidateSkillService.Display(context);
        }
        [Route("api/CandidateSkillController")]
        [HttpDelete]
        public void Delete(int skillID, int candidateID)
        {
            CandidateSkillService.Remove(context, skillID, candidateID);
        }
        [Route("api/CandidateSkillController")]
        [HttpPut]
        public void Update(int skillID, int candidateID, int month, string level)
        {
            CandidateSkillService.Update(context, skillID, candidateID, month, level);
        }
        [Route("api/CandidateSkillController")]
        [HttpPost]
        public void Create(int skillID, int candidateID, int month, string level)
        {
            CandidateSkillService.Create(context, skillID, candidateID, month, level);


        }
    }
}