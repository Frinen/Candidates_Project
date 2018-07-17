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
    [Route("api/CandidateSchoolController")]
    public class CandidateSchoolController:Controller
    {
        private readonly CandidatesContext context;

        public CandidateSchoolController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [HttpGet]
        public CandidateSchool Details(int highSchoolID, int candidateID)
        {
            return CandidateSchoolService.Viev(context, highSchoolID, candidateID);
        }
        [HttpDelete]
        public void Delete(int highSchoolID, int candidateID)
        {
            CandidateSchoolService.Delete(context, highSchoolID, candidateID);
        }

        [HttpPut]
        public void Change(int highSchoolID, int candidateID, CandidateSchool candidate)
        {

        }

        [HttpPost]
        public void Add(int highSchoolID, int candidateID, string from, string to, string degree)
        {
            CandidateSchoolService.Add(context, highSchoolID, candidateID, from, to, degree);


        }
    }
}
