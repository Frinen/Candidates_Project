using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Candidates_Project.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _service;
        public AccountController (IAccountService service)
        {
            _service = service;
        }
        [Route("api/AccountController/AccountDTO")]
        [HttpPost]
        public string RequestToken(AccountDTO person)
        {
            return _service.RequestToken(person);
        }
        [Route("api/AccountController/id")]
        [HttpGet]
        [Authorize(Roles = "admin")]
        public Task<AccountDTO> Get(string login)
        {
            return _service.GetAsync(login);
        }
        [Route("api/AccountController/")]
        [HttpGet]
        public PageResponse<AccountShortDTO> Get(QuerySettings settings)
        {
            return _service.Get(settings);
        }
        [Route("api/AccountController/")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public void Delete(string login)
        {
            _service.RemoveAsync(login);
        }
        [Route("api/AccountController/")]
        [HttpPut]
        [Authorize(Roles = "admin")]
        public void Update(AccountDTO candidate)
        {
            _service.UpdateAsync(candidate);
        }
        [Route("api/AccountController/")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public void Create(AccountDTO candidate)
        {
            _service.CreateAsync(candidate);
        }

    }
}