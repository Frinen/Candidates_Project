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
    
    public class SkillController : Controller
    {
        private readonly ISkillService service;

        public SkillController(ISkillService _service)
        {
            service = _service;
        }

        // GET: Default/Details/5
        [Route("api/Skill/id")]
        [HttpGet]
        public SkillDTO Get(int id)
        {
            return service.Get(id);
        }
        [Route("api/Skill")]
        [HttpGet]
        public IQueryable<SkillDTO> Get()
        {
            return service.Get();
        }
        [Route("api/Skill")]
        [HttpDelete]
        public void Delete(int id)
        {
            service.Remove(id);
        }
        [Route("api/Skill")]
        [HttpPut]
        public void Change(int id, SkillShortDTO skill)
        {
            service.Update(id, skill);
        }
        [Route("api/Skill")]
        [HttpPost]
        public void Create(SkillShortDTO skill)
        {
            service.Create(skill);
            
        }
    }
}