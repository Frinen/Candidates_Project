using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services;
using Candidates.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Candidates_Project.Controllers
{
    
    public class HighSchoolController : Controller
    {
        private readonly IHighSchoolService service;

        public HighSchoolController(IHighSchoolService _service)
        {
            service = _service;
        }

        // GET: Default/Details/5
        [Route("api/HighSchoolController/id")]
        [HttpGet]
        public HighSchool Display(int id)
        {
            return service.Display(id);
        }
        [Route("api/HighSchoolController")]
        [HttpGet]
        public List<HighSchool> Display()
        {
            return service.Display();
        }
        [Route("api/HighSchoolController")]
        [HttpDelete]
        public void Delete(int id)
        {
            service.Remove(id);
        }
        [Route("api/HighSchoolController")]
        [HttpPut]
        public void Update(int id, string name)
        {
            service.Update(id, name);
        }
        [Route("api/HighSchoolController")]
        [HttpPost]
        public void Create(string name)
        {
            service.Create( name);


        }
    }
}