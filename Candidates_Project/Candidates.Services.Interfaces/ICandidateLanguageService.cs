using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateLanguageService
    {
        void Create(int languageID, int candidateID, string level);
        void Update(int languageID, int candidateID, string level);
        void Remove(int languageID, int candidateID);
        CandidateLanguageDTO Display(int languageID, int candidateID);
        IQueryable<CandidateLanguageDTO> Display();
    }
}
