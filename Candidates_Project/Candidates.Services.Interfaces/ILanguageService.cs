using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ILanguageService
    {
        void Create(LanguageShortDTO languageDTO);
        void Update(LanguageDTO languageDTO);
        void Remove(int id);
        LanguageDTO Get(int id);
        PageResponse<LanguageDTO> Get(QuerySettings settings);
    }
}
