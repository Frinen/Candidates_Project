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
using Microsoft.AspNetCore.Authorization;
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
        public Task<CandidateLanguageDTO> Get(int languageID, int candidateID)
        {
            return _service.GetAsync( languageID, candidateID);
        }
        [Route("api/CandidatesLanguages/")]
        [HttpGet]
        public PageResponse<CandidateLanguageDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/CandidatesLanguages/")]
        [HttpDelete]
        [Authorize(Roles = "hr")]
        public void Delete(int languageID, int candidateID)
        {
            _service.RemoveAsync( languageID, candidateID);
        }
        [Route("api/CandidatesLanguages/")]
        [HttpPut]
        [Authorize(Roles = "hr")]
        public void Update(CandidateLanguageDTO candidateLanguage)
        {
            _service.UpdateAsync(candidateLanguage);
        }
        [Route("api/CandidatesLanguages/")]
        [HttpPost]
        [Authorize(Roles = "hr")]
        public void Create(CandidateLanguageDTO candidateLanguage)
        {
            _service.CreateAsync(candidateLanguage);
            
        }
    }
}