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
    public interface ICandidateSkillService
    {
        void CreateAsync(CandidateSkillDTO candidateSkillDTO);
        void UpdateAsync(CandidateSkillDTO candidateSkillDTO);
        void RemoveAsync(int skillID, int candidateID);
        Task<CandidateSkillDTO> GetAsync(int skillID, int candidateID);
        PageResponse<CandidateSkillDTO> Get(QuerySettings settings);
    }
}
