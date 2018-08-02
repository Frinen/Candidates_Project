using AutoMapper;
using Candidates.Library;
using Candidates.Models.Context;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Candidates.Services
{
    public class AccountService : IAccountService
    {
        private CandidatesContext _context;
        public AccountService(CandidatesContext context)
        {
            _context = context;
        }
        public async void CreateAsync(AccountDTO accountDTO)
        {
            await _context.Database.EnsureCreatedAsync();
            var account = Mapper.Map<AccountDTO, Account>(accountDTO);
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
        public async void UpdateAsync(AccountDTO accountDTO)
        {
            var account = Mapper.Map<AccountDTO, Account>(accountDTO);
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
        public async void RemoveAsync(string login)
        {
            var account = await _context.Accounts.FindAsync(login);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<AccountDTO> GetAsync(string login)
        {
            var  account = await _context.Accounts.FindAsync(login);
            var accountDTO = Mapper.Map<Account, AccountDTO>(account);
            return accountDTO;
        }
        public PageResponse<AccountShortDTO> Get(QuerySettings settings)
        {
            var response = new PageResponse<AccountShortDTO>();
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.Accounts.Count())
            {
                IEnumerable<Account> accountsPage= _context.Accounts.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                var accountsPageDTO = Mapper.Map<IEnumerable<Account>, IEnumerable<AccountShortDTO>>(accountsPage);
                response.List = accountsPageDTO;
                response.PageCount = _context.Accounts.Count() / settings.PageSize;
                response.ItemCount = _context.Accounts.Count();
                // response.Message = "Ok";
            }
            else
            {
                //response.Message = $" Incorrect page or item count, max item count: { _context.CandidateLanguages.Count() }";
                response.ItemCount = _context.Accounts.Count();
            }
            return response;
        }
        public string RequestToken(AccountDTO person)
        {
            if (_context.Accounts.FirstOrDefault(x => x.Login == person.Login && x.Password == person.Password) != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };

                var key = AuthOptions.GetSymmetricSecurityKey();
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return (new JwtSecurityTokenHandler().WriteToken(token)  );
            }

            return ("Could not verify username and password");
        }
    }
}
