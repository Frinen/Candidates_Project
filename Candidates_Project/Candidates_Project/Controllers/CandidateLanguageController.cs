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
    
    public class CandidateLanguageController : Controller
    {
        private readonly CandidatesContext context;

        public CandidateLanguageController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [Route("api/CandidateLanguageController/id")]
        [HttpGet]
        public CandidateLanguage Details(int languageID, int candidateID)
        {
            return CandidateLanguageService.Display(context, languageID, candidateID);
        }
        [Route("api/CandidateLanguageController/")]
        [HttpGet]
        public List<CandidateLanguage> Details()
        {
            return CandidateLanguageService.Display(context);
        }
        [Route("api/CandidateLanguageController/")]
        [HttpDelete]
        public void Delete(int languageID, int candidateID)
        {
            CandidateLanguageService.Remove(context, languageID, candidateID);
        }
        [Route("api/CandidateLanguageController/")]
        [HttpPut]
        public void Update(int languageID, int candidateID, string level)
        {
            CandidateLanguageService.Update(context, languageID, candidateID, level);
        }
        [Route("api/CandidateLanguageController/")]
        [HttpPost]
        public void Create(int languageID, int candidateID, string level)
        {
            CandidateLanguageService.Create(context, languageID, candidateID, level);
            
        }
    }
}