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
        private readonly ICandidateService service;

        public CandidateController(ICandidateService _service)
        {
            service = _service;
        }

        // GET: Default/Details/5
        [Route("api/CandidateController/id")]
        [HttpGet]
        public Candidate Details(int id)
        {
            return service.Display(id);
        }
        [Route("api/CandidateController/")]
        [HttpGet]
        public List<Candidate> Details()
        {
            return service.Display();
        }
        [Route("api/CandidateController/")]
        [HttpDelete]
        public void Delete(int id)
        {
            service.Remove(id);
        }
        [Route("api/CandidateController/")]
        [HttpPut]
        public void Update( int id, string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            service.Update( id, firstName,  lastName, birthDate, sex, phoneNumber, email, skype);
        }
        [Route("api/CandidateController/")]
        [HttpPost]
        public void Create(string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            service.Create( firstName, lastName, birthDate, sex, phoneNumber, email, skype);

            
        }



    }
}
