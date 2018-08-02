using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Candidates.Services.Interfaces
{
    public interface IAccountService
    {
        void CreateAsync(AccountDTO accountDTO);
        void UpdateAsync(AccountDTO accountDTO);
        void RemoveAsync(string login);
        Task<AccountDTO> GetAsync(string login);
        PageResponse<AccountShortDTO> Get(QuerySettings settings);
        string RequestToken(AccountDTO person);
    }
}
