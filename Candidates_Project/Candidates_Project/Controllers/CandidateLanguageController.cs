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
    
    public class CandidateLanguageController : Controller
    {
        private readonly ICandidateLanguageService service;

        public CandidateLanguageController(ICandidateLanguageService _service)
        {
            service = _service;
        }

        // GET: Default/Details/5
        [Route("api/CandidateLanguageController/languageID&candidateID")]
        [HttpGet]
        public CandidateLanguageDTO Details(int languageID, int candidateID)
        {
            return service.Display( languageID, candidateID);
        }
        [Route("api/CandidateLanguageController/")]
        [HttpGet]
        public IQueryable<CandidateLanguageDTO> Details()
        {
            return service.Display();
        }
        [Route("api/CandidateLanguageController/")]
        [HttpDelete]
        public void Delete(int languageID, int candidateID)
        {
            service.Remove( languageID, candidateID);
        }
        [Route("api/CandidateLanguageController/")]
        [HttpPut]
        public void Update(int languageID, int candidateID, string level)
        {
            service.Update( languageID, candidateID, level);
        }
        [Route("api/CandidateLanguageController/")]
        [HttpPost]
        public void Create(int languageID, int candidateID, string level)
        {
            service.Create( languageID, candidateID, level);
            
        }
    }
}