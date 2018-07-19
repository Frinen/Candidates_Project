using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateSkillService
    {
        void Create(int skillID, int candidateID, int month, string level);
        void Update(int skillID, int candidateID, int month, string level);
        void Remove(int skillID, int candidateID);
        CandidateSkill Display(int skillID, int candidateID);
        List<CandidateSkill> Display();
    }
}
