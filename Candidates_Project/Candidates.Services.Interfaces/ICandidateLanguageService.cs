using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateLanguageService
    {
        void Create(CandidateLanguageDTO candidateLanguageDTO);
        void Update(CandidateLanguageDTO candidateLanguageDTO);
        void Remove(int languageID, int candidateID);
        CandidateLanguageDTO Get(int languageID, int candidateID);
        PageResponse<CandidateLanguageDTO> Get(QuerySettings settings);
    }
}
