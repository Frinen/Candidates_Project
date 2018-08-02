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
    public interface ICandidateLanguageService
    {
        void CreateAsync(CandidateLanguageDTO candidateLanguageDTO);
        void UpdateAsync(CandidateLanguageDTO candidateLanguageDTO);
        void RemoveAsync(int languageID, int candidateID);
        Task<CandidateLanguageDTO> GetAsync(int languageID, int candidateID);
        PageResponse<CandidateLanguageDTO> Get(QuerySettings settings);
    }
}
