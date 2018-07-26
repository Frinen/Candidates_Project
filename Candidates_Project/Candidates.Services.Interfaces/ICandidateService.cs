using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateService
    {
        void Create(CandidateDTO candidate);
        void Update(int id, CandidateDTO candidate);
        void Remove(int id);
        CandidateDetailsDTO Get(int id);
        IQueryable<CandidateShortDTO> GetPage(int page, int pageSize);
    }
}
