using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateLanguageService
    {
        void Create(CandidateLanguageDTO candidateLanguage);
        void Update(int languageID, int candidateID, CandidateLanguageShortDTO candidateLanguage);
        void Remove(int languageID, int candidateID);
        CandidateLanguageDTO Get(int languageID, int candidateID);
        IQueryable<CandidateLanguageDTO> Get();
    }
}
