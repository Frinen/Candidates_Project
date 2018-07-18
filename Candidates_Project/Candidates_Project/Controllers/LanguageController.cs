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
    [Route("api/LanguageController")]
    public class LanguageController : Controller
    {
        private readonly CandidatesContext context;

        public LanguageController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [HttpGet]
        public Language Display(int id)
        {
            return LanguageService.Display(context, id);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            LanguageService.Remove(context, id);
        }

        [HttpPut]
        public void Update(int id, Language language)
        {

        }

        [HttpPost]
        public void Create(string name)
        {
            LanguageService.Create(context, name);


        }
    }
}