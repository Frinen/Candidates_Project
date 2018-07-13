using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.Context;
using Candidates.Services;

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
        public ActionResult Details()
        {
            return View();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return View();
        }
        
        [HttpPut]
        public ActionResult Change()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            AddEntity.AddCandidate(context, firstName, lastName, birthDate, sex, phoneNumber, email, skype);

            return View();
        }



    }
}
