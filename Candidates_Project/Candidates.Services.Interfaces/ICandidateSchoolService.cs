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
    public interface ICandidateSchoolService
    {
        void CreateAsync(CandidateSchoolDTO candidateSchoolDTO);
        void UpdateAsync(CandidateSchoolDTO candidateSchoolDTO);
        void RemoveAsync(int highSchoolID, int candidateID);
        Task<CandidateSchoolDTO> GetAsync(int highSchoolID, int candidateID);
        PageResponse<CandidateSchoolDTO> Get(QuerySettings settings);
    }
}
