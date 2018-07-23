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
        [Route("api/OptionController/id")]
        [HttpGet]
        public OptionsDTO Display(int id)
        {
            return service.Display(id);
        }
        [Route("api/OptionController")]
        [HttpGet]
        public IQueryable<OptionsDTO> Display()
        {
            return service.Display();
        }
        [Route("api/OptionController")]
        [HttpDelete]
        public void Delete(int id)
        {
            service.Remove(id);
        }
        [Route("api/OptionController")]
        [HttpPut]
        public void Update(int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice)
        {
            service.Update(candidateID, canWorkRemotly, canRelocate, canWorkInTheOffice);
        }
        [Route("api/OptionController")]
        [HttpPost]
        public void Create(int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice)
        {
            service.Create( candidateID, canWorkRemotly, canRelocate, canWorkInTheOffice);
        }
    }
}