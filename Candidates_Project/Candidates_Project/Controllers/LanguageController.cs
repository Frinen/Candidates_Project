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
    
    public class LanguageController : Controller
    {
        private readonly ILanguageService service;

        public LanguageController(ILanguageService _service)
        {
            service = _service;
        }

        // GET: Default/Details/5
        [Route("api/Language/id")]
        [HttpGet]
        public LanguageDTO Get(int id)
        {
            return service.Get( id);
        }
        [Route("api/Language")]
        [HttpGet]
        public IQueryable<LanguageDTO> Get()
        {
            return service.Get();
        }
        [Route("api/Language")]
        [HttpDelete]
        public void Delete(int id)
        {
            service.Remove(id);
        }
        [Route("api/Language")]
        [HttpPut]
        public void Update(int id, LanguageShortDTO language)
        {
            service.Update(id, language);
        }
        [Route("api/Language")]
        [HttpPost]
        public void Create(LanguageShortDTO language)
        {
            service.Create(language);
        }
    }
}