using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ILanguageService
    {
        void Create(string name);
        void Update(int id, string name);
        void Remove(int id);
        LanguageDTO Display(int id);
        IQueryable<LanguageDTO> Display();
    }
}
