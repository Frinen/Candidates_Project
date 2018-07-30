using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Candidates.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateSkillService
    {
        void Create(CandidateSkillDTO candidateSkillDTO);
        void Update(CandidateSkillDTO candidateSkillDTO);
        void Remove(int skillID, int candidateID);
        CandidateSkillDTO Get(int skillID, int candidateID);
        CandidateSkillResponse Get(QuerySettings settings);
    }
}
