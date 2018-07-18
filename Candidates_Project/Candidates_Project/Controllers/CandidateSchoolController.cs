using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Controllers
{
    
    public class CandidateSchoolController:Controller
    {
        private readonly CandidatesContext context;

        public CandidateSchoolController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [Route("api/CandidateSchoolController/highSchoolID&candidateID")]
        [HttpGet]
        public CandidateSchool Details(int highSchoolID, int candidateID)
        {
            return CandidateSchoolService.Display(context, highSchoolID, candidateID);
        }
        [Route("api/CandidateSchoolController")]
        [HttpGet]
        public List<CandidateSchool> Details()
        {
            return CandidateSchoolService.Display(context);
        }
        [Route("api/CandidateSchoolController")]
        [HttpDelete]
        public void Delete(int highSchoolID, int candidateID)
        {
            CandidateSchoolService.Remove(context, highSchoolID, candidateID);
        }
        [Route("api/CandidateSchoolController")]
        [HttpPut]
        public void Update(int highSchoolID, int candidateID, string from, string to, string degree)
        {
            CandidateSchoolService.Update(context, highSchoolID, candidateID, from, to, degree);
        }
        [Route("api/CandidateSchoolController")]
        [HttpPost]
        public void Create(int highSchoolID, int candidateID, string from, string to, string degree)
        {
            CandidateSchoolService.Create(context, highSchoolID, candidateID, from, to, degree);


        }
    }
}
