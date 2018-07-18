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
    
    public class CandidateController : Controller
    {
        private readonly CandidatesContext context;

        public CandidateController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [Route("api/CandidateController/id")]
        [HttpGet]
        public Candidate Details(int id)
        {
            return CandidateService.Display(context, id);
        }
        [Route("api/CandidateController/")]
        [HttpGet]
        public List<Candidate> Details()
        {
            return CandidateService.Display(context);
        }
        [Route("api/CandidateController/")]
        [HttpDelete]
        public void Delete(int id)
        {
            CandidateService.Remove(context,id);
        }
        [Route("api/CandidateController/")]
        [HttpPut]
        public void Update( int id, string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            CandidateService.Update(context, id, firstName,  lastName, birthDate, sex, phoneNumber, email, skype);
        }
        [Route("api/CandidateController/")]
        [HttpPost]
        public void Create(string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            CandidateService.Create(context, firstName, lastName, birthDate, sex, phoneNumber, email, skype);

            
        }



    }
}
