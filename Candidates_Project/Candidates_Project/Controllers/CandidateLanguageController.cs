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
        private readonly ICandidateLanguageService _service;

        public CandidateLanguageController(ICandidateLanguageService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/CandidateLanguage/languageID&candidateID")]
        [HttpGet]
        public CandidateLanguageDTO Get(int languageID, int candidateID)
        {
            return _service.Get( languageID, candidateID);
        }
        [Route("api/CandidateLanguage/")]
        [HttpGet]
        public IQueryable<CandidateLanguageDTO> Get()
        {
            return _service.Get();
        }
        [Route("api/CandidateLanguage/")]
        [HttpDelete]
        public void Delete(int languageID, int candidateID)
        {
            _service.Remove( languageID, candidateID);
        }
        [Route("api/CandidateLanguage/")]
        [HttpPut]
        public void Update(int languageID, int candidateID, CandidateLanguageShortDTO candidateLanguage)
        {
            _service.Update( languageID, candidateID, candidateLanguage);
        }
        [Route("api/CandidateLanguage/")]
        [HttpPost]
        public void Create(CandidateLanguageDTO candidateLanguage)
        {
            _service.Create(candidateLanguage);
            
        }
    }
}