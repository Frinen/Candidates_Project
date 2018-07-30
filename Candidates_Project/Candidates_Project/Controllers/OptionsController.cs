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
using Candidates.Responses;

namespace Candidates_Project.Controllers
{
   
    public class OptionsController : Controller
    {
        private readonly IOptionsService _service;

        public OptionsController(IOptionsService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/Options/id")]
        [HttpGet]
        public OptionsDTO Get(int id)
        {
            return _service.Get(id);
        }
        [Route("api/Options")]
        [HttpGet]
        public OptionsResponse Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/Options")]
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Remove(id);
        }
        [Route("api/Options")]
        [HttpPut]
        public void Update(OptionsDTO options)
        {
            _service.Update(options);
        }
        [Route("api/Options")]
        [HttpPost]
        public void Create(OptionsDTO options)
        {
            _service.Create(options);
        }
    }
}