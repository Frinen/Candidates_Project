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
        private readonly ILanguageService _service;

        public LanguageController(ILanguageService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/Language/id")]
        [HttpGet]
        public LanguageDTO Get(int id)
        {
            return _service.Get( id);
        }
        [Route("api/Language")]
        [HttpGet]
        public IQueryable<LanguageDTO> Get()
        {
            return _service.Get();
        }
        [Route("api/Language")]
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
        [Route("api/Language")]
        [HttpPut]
        public void Update(int id, LanguageShortDTO language)
        {
            _service.Update(id, language);
        }
        [Route("api/Language")]
        [HttpPost]
        public void Create(LanguageShortDTO language)
        {
            _service.Create(language);
        }
    }
}