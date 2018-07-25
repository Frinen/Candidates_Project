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
        [Route("api/HighSchool/id")]
        [HttpGet]
        public HighSchoolDTO Get(int id)
        {
            return service.Get(id);
        }
        [Route("api/HighSchool")]
        [HttpGet]
        public IQueryable<HighSchoolDTO> Get()
        {
            return service.Get();
        }
        [Route("api/HighSchool")]
        [HttpDelete]
        public void Delete(int id)
        {
            service.Remove(id);
        }
        [Route("api/HighSchool")]
        [HttpPut]
        public void Update(int id, HighSchoolShortDTO highSchool)
        {
            service.Update(id, highSchool);
        }
        [Route("api/HighSchool")]
        [HttpPost]
        public void Create(HighSchoolShortDTO highSchool)
        {
            service.Create(highSchool);


        }
    }
}