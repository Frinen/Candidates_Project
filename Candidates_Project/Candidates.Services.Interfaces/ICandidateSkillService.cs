using Candidates.Library;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateSkillService
    {
        void Create(CandidateSkillDTO candidateSkill);
        void Update(int skillID, int candidateID, CandidateSkillShortDTO candidateSkill);
        void Remove(int skillID, int candidateID);
        CandidateSkillDTO Get(int skillID, int candidateID);
        IQueryable<CandidateSkillDTO> Get(QuerySettings settings);
    }
}
