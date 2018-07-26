using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.Context;
using Candidates.Services;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;

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
        public CandidateDetailsDTO Get(int id)
        {
            return _service.Get(id);
        }
        [Route("api/Candidates/")]
        [HttpGet]
        public IQueryable<CandidateShortDTO> GetPage(int page, int pageSize)
        {
            return _service.GetPage(page, pageSize);
        }
        [Route("api/Candidates/")]
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
        [Route("api/Candidates/")]
        [HttpPut]
        public void Update( int id, CandidateDTO candidate)
        {
            _service.Update( id, candidate);
        }
        [Route("api/Candidates/")]
        [HttpPost]
        public void Create(CandidateDTO candidate)
        {
            _service.Create(candidate);

            
        }



    }
}
