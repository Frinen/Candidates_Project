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
        [Route("api/CandidateSchoolController/highSchoolID&candidateID")]
        [HttpGet]
        public CandidateSchool Details(int highSchoolID, int candidateID)
        {
            return service.Display(highSchoolID, candidateID);
        }
        [Route("api/CandidateSchoolController")]
        [HttpGet]
        public List<CandidateSchool> Details()
        {
            return service.Display();
        }
        [Route("api/CandidateSchoolController")]
        [HttpDelete]
        public void Delete(int highSchoolID, int candidateID)
        {
            service.Remove(highSchoolID, candidateID);
        }
        [Route("api/CandidateSchoolController")]
        [HttpPut]
        public void Update(int highSchoolID, int candidateID, string from, string to, string degree)
        {
            service.Update( highSchoolID, candidateID, from, to, degree);
        }
        [Route("api/CandidateSchoolController")]
        [HttpPost]
        public void Create(int highSchoolID, int candidateID, string from, string to, string degree)
        {
            service.Create(highSchoolID, candidateID, from, to, degree);


        }
    }
}
