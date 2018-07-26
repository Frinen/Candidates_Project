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

namespace Candidates_Project.Controllers
{
    
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _service;

        public LanguagesController(ILanguageService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/Languages/id")]
        [HttpGet]
        public LanguageDTO Get(int id)
        {
            return _service.Get( id);
        }
        [Route("api/Languages")]
        [HttpGet]
        public IQueryable<LanguageDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/Languages")]
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
        [Route("api/Languages")]
        [HttpPut]
        public void Update(int id, LanguageShortDTO language)
        {
            _service.Update(id, language);
        }
        [Route("api/Languages")]
        [HttpPost]
        public void Create(LanguageShortDTO language)
        {
            _service.Create(language);
        }
    }
}