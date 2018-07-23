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
        [Route("api/SkillController/id")]
        [HttpGet]
        public SkillDTO Dispaly(int id)
        {
            return service.Display(id);
        }
        [Route("api/SkillController")]
        [HttpGet]
        public IQueryable<SkillDTO> Dispaly()
        {
            return service.Display();
        }
        [Route("api/SkillController")]
        [HttpDelete]
        public void Delete(int id)
        {
            service.Remove(id);
        }
        [Route("api/SkillController")]
        [HttpPut]
        public void Change(int id, string name)
        {
            service.Update(id, name);
        }
        [Route("api/SkillController")]
        [HttpPost]
        public void Create(string name)
        {
            service.Create(name);
            
        }
    }
}