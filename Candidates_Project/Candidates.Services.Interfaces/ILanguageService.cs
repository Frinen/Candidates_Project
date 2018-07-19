using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ILanguageService
    {
        void Create(string name);
        void Update(int id, string name);
        void Remove(int id);
        Language Display(int id);
        List<Language> Display();
    }
}
