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
    [Route("api/TestController")]
    public class TestController : Controller
    {
        private readonly CandidatesContext context;

        public TestController (CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [HttpGet]
        public Candidate Details(int id)
        {
            return VievEntity.VievCandidate(context, id);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            RemoveEntity.DeleteCandidate(context,id);
        }
        
        [HttpPut]
        public ActionResult Change()
        {
            return View();
        }
        
        [HttpPost]
        public void Add(string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            AddEntity.AddCandidate(context, firstName, lastName, birthDate, sex, phoneNumber, email, skype);

            
        }



    }
}
