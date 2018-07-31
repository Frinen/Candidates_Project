using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface IAccountService
    {
        void Create(AccountDTO accountDTO);
        void Update(AccountDTO accountDTO);
        void Remove(string login);
        AccountDTO Get(string login);
        PageResponse<AccountShortDTO> Get(QuerySettings settings);
        string RequestToken(AccountDTO person);
    }
}
