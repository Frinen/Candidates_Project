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
    [Route("api/SkillController")]
    public class SkillController : Controller
    {
        private readonly CandidatesContext context;

        public SkillController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [HttpGet]
        public Skill Dispaly(int id)
        {
            return SkillService.Display(context, id);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            SkillService.Remove(context, id);
        }

        [HttpPut]
        public void Change(int id, Skill skill)
        {

        }

        [HttpPost]
        public void Create(string name)
        {
            SkillService.Create(context, name);


        }
    }
}