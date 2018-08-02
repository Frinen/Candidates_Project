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
using Microsoft.AspNetCore.Authorization;

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
        public Task<HighSchoolDTO> Get(int id)
        {
            return _service.GetAsync(id);
        }
        [Route("api/HighSchools")]
        [HttpGet]
        public PageResponse<HighSchoolDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/HighSchools")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public void Delete(int id)
        {
            _service.RemoveAsync(id);
        }
        [Route("api/HighSchools")]
        [HttpPut]
        [Authorize(Roles = "admin")]
        public void Update(HighSchoolDTO highSchool)
        {
            _service.UpdateAsync(highSchool);
        }
        [Route("api/HighSchools")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public void Create(HighSchoolShortDTO highSchool)
        {
            _service.CreateAsync(highSchool);


        }
    }
}