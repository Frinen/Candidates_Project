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
    
    public class SkillsController : Controller
    {
        private readonly ISkillService _service;

        public SkillsController(ISkillService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/Skills/id")]
        [HttpGet]
        public SkillDTO Get(int id)
        {
            return _service.Get(id);
        }
        [Route("api/Skills")]
        [HttpGet]
        public List<SkillDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/Skills")]
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
        [Route("api/Skills")]
        [HttpPut]
        public void Change(SkillDTO skill)
        {
            _service.Update(skill);
        }
        [Route("api/Skills")]
        [HttpPost]
        public void Create(SkillShortDTO skill)
        {
            _service.Create(skill);
            
        }
    }
}