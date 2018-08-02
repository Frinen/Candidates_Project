using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.Context;
using Candidates.Services;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using Candidates.Library;
using Candidates.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Candidates_Project.Controllers
{
    
    public class CandidatesController : Controller
    {
        private readonly ICandidateService _service;

        public CandidatesController(ICandidateService service)
        {
            _service = service;
        }
        [Route("api/Candidates/id")]
        [HttpGet]
        public Task<CandidateDetailsDTO> Get(int id)
        {
            return _service.GetAsync(id);
        }
        [Route("api/Candidates/")]
        [HttpGet]
        public PageResponse<CandidateShortDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/Candidates/")]
        [Authorize(Roles = "hr")]
        [HttpDelete]
        public void Delete(int id)
        {
            _service.RemoveAsync(id);
        }
        [Route("api/Candidates/")]
        [HttpPut]
        [Authorize(Roles = "hr")]
        public void Update(CandidateDetailsDTO candidate)
        {
            _service.UpdateAsync(candidate);
        }
        [Route("api/Candidates/")]
        [HttpPost]
        [Authorize(Roles = "hr")]
        public void Create(CandidateDTO candidate)
        {
            _service.CreateAsync(candidate);
        }
    }
}
