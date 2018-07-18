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
    
    public class SkillController : Controller
    {
        private readonly CandidatesContext context;

        public SkillController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [Route("api/SkillController/id")]
        [HttpGet]
        public Skill Dispaly(int id)
        {
            return SkillService.Display(context, id);
        }
        [Route("api/SkillController")]
        [HttpGet]
        public List<Skill> Dispaly()
        {
            return SkillService.Display(context);
        }
        [Route("api/SkillController")]
        [HttpDelete]
        public void Delete(int id)
        {
            SkillService.Remove(context, id);
        }
        [Route("api/SkillController")]
        [HttpPut]
        public void Change(int id, Skill skill)
        {

        }
        [Route("api/SkillController")]
        [HttpPost]
        public void Create(string name)
        {
            SkillService.Create(context, name);
            
        }
    }
}