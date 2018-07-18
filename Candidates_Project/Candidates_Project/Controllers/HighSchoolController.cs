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
    
    public class HighSchoolController : Controller
    {
        private readonly CandidatesContext context;

        public HighSchoolController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [Route("api/HighSchoolController/id")]
        [HttpGet]
        public HighSchool Display(int id)
        {
            return HighSchoolService.Display(context, id);
        }
        [Route("api/HighSchoolController")]
        [HttpGet]
        public List<HighSchool> Display()
        {
            return HighSchoolService.Display(context);
        }
        [Route("api/HighSchoolController")]
        [HttpDelete]
        public void Delete(int id)
        {
            HighSchoolService.Remove(context, id);
        }
        [Route("api/HighSchoolController")]
        [HttpPut]
        public void Update(int id, string name)
        {
            HighSchoolService.Update(context, id, name);
        }
        [Route("api/HighSchoolController")]
        [HttpPost]
        public void Create(string name)
        {
            HighSchoolService.Create(context, name);


        }
    }
}