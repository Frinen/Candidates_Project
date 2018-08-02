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
    public interface ICandidateService
    {
        void CreateAsync(CandidateDTO candidateDTO);
        void UpdateAsync(CandidateDetailsDTO candidateDTO);
        void RemoveAsync(int id);
        Task<CandidateDetailsDTO> GetAsync(int id);
        PageResponse<CandidateShortDTO> Get(QuerySettings settings);
    }
}
