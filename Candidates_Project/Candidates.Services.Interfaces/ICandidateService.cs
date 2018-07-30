using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateService
    {
        void Create(CandidateDTO candidateDTO);
        void Update(CandidateDetailsDTO candidateDTO);
        void Remove(int id);
        CandidateDetailsDTO Get(int id);
        List<CandidateShortDTO> Get(QuerySettings settings);
    }
}
