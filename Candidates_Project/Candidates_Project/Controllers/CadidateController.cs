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
    
    public class CandidateController : Controller
    {
        private readonly ICandidateService _service;

        public CandidateController(ICandidateService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/Candidate/id")]
        [HttpGet]
        public CandidateDetailsDTO Get(int id)
        {
            return _service.Get(id);
        }
        [Route("api/Candidate/")]
        [HttpGet]
        public IQueryable<CandidateShortDTO> Get()
        {
            return _service.Get();
        }
        [Route("api/Candidate/")]
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
        [Route("api/Candidate/")]
        [HttpPut]
        public void Update( int id, CandidateDTO candidate)
        {
            _service.Update( id, candidate);
        }
        [Route("api/Candidate/")]
        [HttpPost]
        public void Create(CandidateDTO candidate)
        {
            _service.Create(candidate);

            
        }



    }
}
