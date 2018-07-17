using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.Context;
using Candidates.Services;
using Candidates.Models.Models;

namespace Candidates_Project.Controllers
{
    [Route("api/CandidateController")]
    public class CandidateController : Controller
    {
        private readonly CandidatesContext context;

        public CandidateController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [HttpGet]
        public Candidate Details(int id)
        {
            return CandidateService.VievCandidate(context, id);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            CandidateService.DeleteCandidate(context,id);
        }
        
        [HttpPut]
        public void Change( int id, Candidate candidate)
        {
            
        }
        
        [HttpPost]
        public void Add(string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            CandidateService.AddCandidate(context, firstName, lastName, birthDate, sex, phoneNumber, email, skype);

            
        }



    }
}
