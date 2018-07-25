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
   
    public class OptionsController : Controller
    {
        private readonly IOptionsService service;

        public OptionsController(IOptionsService _service)
        {
            service = _service;
        }

        // GET: Default/Details/5
        [Route("api/Options/id")]
        [HttpGet]
        public OptionsDTO Get(int id)
        {
            return service.Get(id);
        }
        [Route("api/Options")]
        [HttpGet]
        public IQueryable<OptionsDTO> Get()
        {
            return service.Get();
        }
        [Route("api/Options")]
        [HttpDelete]
        public void Delete(int id)
        {
            service.Remove(id);
        }
        [Route("api/Options")]
        [HttpPut]
        public void Update(int candidateID, OptionsShortDTO options)
        {
            service.Update(candidateID, options);
        }
        [Route("api/Options")]
        [HttpPost]
        public void Create(OptionsDTO options)
        {
            service.Create(options);
        }
    }
}