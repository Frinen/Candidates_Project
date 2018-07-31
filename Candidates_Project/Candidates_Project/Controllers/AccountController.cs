using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Candidates.Library;
using Candidates.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Candidates_Project.Controllers
{
    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class AccountController : Controller
    {
        private List<Person> people = new List<Person>
        {
            new Person {Login="admin", Password="admin", Role = "admin" },
            new Person { Login="user", Password="user", Role = "user" }
        };
        [Route("api/AccountController")]
        [HttpPost]
        public IActionResult RequestToken( TokenRequest request)
        {
            if (request.Username == "admin" && request.Password == "admin")
            {
                var claims = new[]
                {
            new Claim(ClaimTypes.Name, request.Username)
        };

                var key = AuthOptions.GetSymmetricSecurityKey();
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Could not verify username and password");
        }
        private ClaimsIdentity GetIdentity(string username, string password)
        {
            Person person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}