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
   
    public class OptionsController : Controller
    {
        private readonly CandidatesContext context;

        public OptionsController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [Route("api/OptionController/id")]
        [HttpGet]
        public Options Display(int id)
        {
            return OptionsService.Display(context, id);
        }
        [Route("api/OptionController")]
        [HttpGet]
        public List<Options> Display()
        {
            return OptionsService.Display(context);
        }
        [Route("api/OptionController")]
        [HttpDelete]
        public void Delete(int id)
        {
            OptionsService.Remove(context, id);
        }
        [Route("api/OptionController")]
        [HttpPut]
        public void Update(int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice)
        {
            OptionsService.Update(context, candidateID, canWorkRemotly, canRelocate, canWorkInTheOffice);
        }
        [Route("api/OptionController")]
        [HttpPost]
        public void Create(int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice)
        {
            OptionsService.Create(context, candidateID, canWorkRemotly, canRelocate, canWorkInTheOffice);


        }
    }
}