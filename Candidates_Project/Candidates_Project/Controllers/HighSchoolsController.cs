using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Library;
using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services;
using Candidates.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Candidates.Models.DTO;

namespace Candidates_Project.Controllers
{
    
    public class HighSchoolsController : Controller
    {
        private readonly IHighSchoolService _service;

        public HighSchoolsController(IHighSchoolService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/HighSchools/id")]
        [HttpGet]
        public HighSchoolDTO Get(int id)
        {
            return _service.Get(id);
        }
        [Route("api/HighSchools")]
        [HttpGet]
        public PageResponse<HighSchoolDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/HighSchools")]
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
        [Route("api/HighSchools")]
        [HttpPut]
        public void Update(HighSchoolDTO highSchool)
        {
            _service.Update(highSchool);
        }
        [Route("api/HighSchools")]
        [HttpPost]
        public void Create(HighSchoolShortDTO highSchool)
        {
            _service.Create(highSchool);


        }
    }
}