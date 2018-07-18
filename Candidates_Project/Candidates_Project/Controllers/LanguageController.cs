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
    
    public class LanguageController : Controller
    {
        private readonly CandidatesContext context;

        public LanguageController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [Route("api/LanguageController/id")]
        [HttpGet]
        public Language Display(int id)
        {
            return LanguageService.Display(context, id);
        }
        [Route("api/LanguageController")]
        [HttpGet]
        public List<Language> Display()
        {
            return LanguageService.Display(context);
        }
        [Route("api/LanguageController")]
        [HttpDelete]
        public void Delete(int id)
        {
            LanguageService.Remove(context, id);
        }
        [Route("api/LanguageController")]
        [HttpPut]
        public void Update(int id, string name)
        {
            LanguageService.Update(context, id, name);
        }
        [Route("api/LanguageController")]
        [HttpPost]
        public void Create(string name)
        {
            LanguageService.Create(context, name);


        }
    }
}