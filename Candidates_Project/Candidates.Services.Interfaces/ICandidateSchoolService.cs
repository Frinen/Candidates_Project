using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateSchoolService
    {
        void Create(CandidateSchoolDTO _candidateSchool);
        void Update(int highSchoolID, int candidateID, CandidateSchoolShortDTO _candidateSchool);
        void Remove(int highSchoolID, int candidateID);
        CandidateSchoolDTO Get(int highSchoolID, int candidateID);
        IQueryable<CandidateSchoolDTO> Get();
    }
}
