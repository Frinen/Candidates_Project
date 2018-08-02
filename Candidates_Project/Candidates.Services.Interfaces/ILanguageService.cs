using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidates.Services.Interfaces
{
    public interface ILanguageService
    {
        void CreateAsync(LanguageShortDTO languageDTO);
        void UpdateAsync(LanguageDTO languageDTO);
        void RemoveAsync(int id);
        Task<LanguageDTO> GetAsync(int id);
        PageResponse<LanguageDTO> Get(QuerySettings settings);
    }
}
