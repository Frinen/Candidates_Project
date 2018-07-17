using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services;
using Microsoft.AspNetCore.Mvc;

namespace Candidates_Project.Controllers
{
    [Route("api/HighSchoolController")]
    public class HighSchoolController : Controller
    {
        private readonly CandidatesContext context;

        public HighSchoolController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [HttpGet]
        public HighSchool Details(int id)
        {
            return HighSchoolService.VievHighSchool(context, id);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            HighSchoolService.DeleteHighSchool(context, id);
        }

        [HttpPut]
        public void Change(int id, HighSchool highschool)
        {

        }

        [HttpPost]
        public void Add(string name)
        {
            HighSchoolService.AddHighSchool(context, name);


        }
    }
}