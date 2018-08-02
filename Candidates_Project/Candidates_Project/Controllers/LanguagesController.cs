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
    
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _service;

        public LanguagesController(ILanguageService service)
        {
            _service = service;
        }

        // GET: Default/Details/5
        [Route("api/Languages/id")]
        [HttpGet]
        public Task<LanguageDTO> Get(int id)
        {
            return _service.GetAsync( id);
        }
        [Route("api/Languages")]
        [HttpGet]
        public PageResponse<LanguageDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/Languages")]
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public void Delete(int id)
        {
            _service.RemoveAsync(id);
        }
        [Route("api/Languages")]
        [HttpPut]
        [Authorize(Roles = "admin")]
        public void Update(LanguageDTO language)
        {
            _service.UpdateAsync(language);
        }
        [Route("api/Languages")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public void Create(LanguageShortDTO language)
        {
            _service.CreateAsync(language);
        }
    }
}