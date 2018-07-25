using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ILanguageService
    {
        void Create(LanguageShortDTO _language);
        void Update(int id, LanguageShortDTO _language);
        void Remove(int id);
        LanguageDTO Get(int id);
        IQueryable<LanguageDTO> Get();
    }
}
