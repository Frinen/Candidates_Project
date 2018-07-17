﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services;
using Microsoft.AspNetCore.Mvc;

namespace Candidates_Project.Controllers
{
    [Route("api/OptionController")]
    public class OptionsController : Controller
    {
        private readonly CandidatesContext context;

        public OptionsController(CandidatesContext _context)
        {
            context = _context;
        }

        // GET: Default/Details/5
        [HttpGet]
        public Options Details(int id)
        {
            return OptionsService.VievOptions(context, id);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            OptionsService.DeleteOptions(context, id);
        }

        [HttpPut]
        public void Change(int id, Options options)
        {

        }

        [HttpPost]
        public void Add(int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice)
        {
            OptionsService.AddOptions(context, candidateID, canWorkRemotly, canRelocate, canWorkInTheOffice);


        }
    }
}