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
        [Route("api/LanguageController/id")]
        [HttpGet]
        public Language Display(int id)
        {
            return service.Display( id);
        }
        [Route("api/LanguageController")]
        [HttpGet]
        public List<Language> Display()
        {
            return service.Display();
        }
        [Route("api/LanguageController")]
        [HttpDelete]
        public void Delete(int id)
        {
            service.Remove(id);
        }
        [Route("api/LanguageController")]
        [HttpPut]
        public void Update(int id, string name)
        {
            service.Update(id, name);
        }
        [Route("api/LanguageController")]
        [HttpPost]
        public void Create(string name)
        {
            service.Create(name);
        }
    }
}