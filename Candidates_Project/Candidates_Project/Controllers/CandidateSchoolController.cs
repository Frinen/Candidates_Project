using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services;
using Candidates.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Controllers
{
    
    public class CandidateSchoolController:Controller
    {
        private readonly ICandidateSchoolService service;

        public CandidateSchoolController(ICandidateSchoolService _service)
        {
            service = _service;
        }

        // GET: Default/Details/5
        [Route("api/CandidateSchool/highSchoolID&candidateID")]
        [HttpGet]
        public CandidateSchoolDTO Get(int highSchoolID, int candidateID)
        {
            return service.Get(highSchoolID, candidateID);
        }
        [Route("api/CandidateSchool")]
        [HttpGet]
        public IQueryable<CandidateSchoolDTO> Get()
        {
            return service.Get();
        }
        [Route("api/CandidateSchool")]
        [HttpDelete]
        public void Delete(int highSchoolID, int candidateID)
        {
            service.Remove(highSchoolID, candidateID);
        }
        [Route("api/CandidateSchool")]
        [HttpPut]
        public void Update(int highSchoolID, int candidateID, CandidateSchoolShortDTO candidateSchool)
        {
            service.Update( highSchoolID, candidateID, candidateSchool);
        }
        [Route("api/CandidateSchool")]
        [HttpPost]
        public void Create(CandidateSchoolDTO candidateSchool)
        {
            service.Create(candidateSchool);


        }
    }
}
