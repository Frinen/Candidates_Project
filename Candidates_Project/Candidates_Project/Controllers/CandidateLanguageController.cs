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
    [Route("api/CandidateLanguageController")]
    public class CandidateLanguageController : Controller
    {
        private readonly CandidatesContext context;

        public CandidateLanguageController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [HttpGet]
        public CandidateLanguage Details(int languageID, int candidateID)
        {
            return CandidateLanguageService.Display(context, languageID, candidateID);
        }
        [HttpDelete]
        public void Delete(int languageID, int candidateID)
        {
            CandidateLanguageService.Remove(context, languageID, candidateID);
        }

        [HttpPut]
        public void Update(int languageID, int candidateID, CandidateSkill candidate)
        {

        }

        [HttpPost]
        public void Create(int languageID, int candidateID, int month, string level)
        {
            CandidateLanguageService.Create(context, languageID, candidateID, level);
            
        }
    }
}