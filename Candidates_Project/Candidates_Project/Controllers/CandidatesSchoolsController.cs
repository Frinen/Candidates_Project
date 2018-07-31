using Candidates.Library;
using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services;
using Candidates.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Candidates_Project.Controllers
{
    
    public class CandidatesSchoolsController:Controller
    {
        private readonly ICandidateSchoolService _service;

        public CandidatesSchoolsController(ICandidateSchoolService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/CandidatesSchools/highSchoolID&candidateID")]
        [HttpGet]
        public CandidateSchoolDTO Get(int highSchoolID, int candidateID)
        {
            return _service.Get(highSchoolID, candidateID);
        }
        [Route("api/CandidatesSchools")]
        [HttpGet]
        public PageResponse<CandidateSchoolDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/CandidatesSchools")]
        [HttpDelete]
        [Authorize(Roles = "hr")]
        public void Delete(int highSchoolID, int candidateID)
        {
            _service.Remove(highSchoolID, candidateID);
        }
        [Route("api/CandidatesSchools")]
        [HttpPut]
        [Authorize(Roles = "hr")]
        public void Update(CandidateSchoolDTO candidateSchool)
        {
            _service.Update(candidateSchool);
        }
        [Route("api/CandidatesSchools")]
        [HttpPost]
        [Authorize(Roles = "hr")]
        public void Create(CandidateSchoolDTO candidateSchool)
        {
            _service.Create(candidateSchool);
        }
    }
}
