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
        public List<CandidateSchoolDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/CandidatesSchools")]
        [HttpDelete]
        public void Delete(int highSchoolID, int candidateID)
        {
            _service.Remove(highSchoolID, candidateID);
        }
        [Route("api/CandidatesSchools")]
        [HttpPut]
        public void Update(int highSchoolID, int candidateID, CandidateSchoolShortDTO candidateSchool)
        {
            _service.Update( highSchoolID, candidateID, candidateSchool);
        }
        [Route("api/CandidatesSchools")]
        [HttpPost]
        public void Create(CandidateSchoolDTO candidateSchool)
        {
            _service.Create(candidateSchool);
        }
    }
}
