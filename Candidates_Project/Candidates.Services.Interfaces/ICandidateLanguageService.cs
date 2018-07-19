using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateLanguageService
    {
        void Create(int languageID, int candidateID, string level);
        void Update(int languageID, int candidateID, string level);
        void Remove(int languageID, int candidateID);
        CandidateLanguage Display(int languageID, int candidateID);
        List<CandidateLanguage> Display();
    }
}
