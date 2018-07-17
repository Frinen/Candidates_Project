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
        public Language Details(int id)
        {
            return LanguageService.VievLanguage(context, id);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            LanguageService.DeleteLanguage(context, id);
        }

        [HttpPut]
        public void Change(int id, Language language)
        {

        }

        [HttpPost]
        public void Add(string name)
        {
            LanguageService.AddLanguage(context, name);


        }
    }
}