using Candidates.Library;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateSchoolService
    {
        void Create(CandidateSchoolDTO candidateSchool);
        void Update(int highSchoolID, int candidateID, CandidateSchoolShortDTO candidateSchool);
        void Remove(int highSchoolID, int candidateID);
        CandidateSchoolDTO Get(int highSchoolID, int candidateID);
        IQueryable<CandidateSchoolDTO> Get(QuerySettings settings);
    }
}
