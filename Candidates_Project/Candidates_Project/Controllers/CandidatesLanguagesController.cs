using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Library;
using Candidates.Models.Context;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Candidates.Services;
using Candidates.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Candidates_Project.Controllers
{
    
    public class CandidatesLanguagesController : Controller
    {
        private readonly ICandidateLanguageService _service;

        public CandidatesLanguagesController(ICandidateLanguageService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/CandidatesLanguages/languageID&candidateID")]
        [HttpGet]
        public CandidateLanguageDTO Get(int languageID, int candidateID)
        {
            return _service.Get( languageID, candidateID);
        }
        [Route("api/CandidatesLanguages/")]
        [HttpGet]
        public PageResponse<CandidateLanguageDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/CandidatesLanguages/")]
        [HttpDelete]
        public void Delete(int languageID, int candidateID)
        {
            _service.Remove( languageID, candidateID);
        }
        [Route("api/CandidatesLanguages/")]
        [HttpPut]
        public void Update(CandidateLanguageDTO candidateLanguage)
        {
            _service.Update(candidateLanguage);
        }
        [Route("api/CandidatesLanguages/")]
        [HttpPost]
        public void Create(CandidateLanguageDTO candidateLanguage)
        {
            _service.Create(candidateLanguage);
            
        }
    }
}