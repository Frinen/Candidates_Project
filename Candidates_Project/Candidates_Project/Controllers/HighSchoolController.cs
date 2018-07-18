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
        public HighSchool Display(int id)
        {
            return HighSchoolService.Display(context, id);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            HighSchoolService.Remove(context, id);
        }

        [HttpPut]
        public void Update(int id, HighSchool highschool)
        {

        }

        [HttpPost]
        public void Create(string name)
        {
            HighSchoolService.Create(context, name);


        }
    }
}