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
    public interface ICandidateSchoolService
    {
        void Create(CandidateSchoolDTO candidateSchoolDTO);
        void Update(CandidateSchoolDTO candidateSchoolDTO);
        void Remove(int highSchoolID, int candidateID);
        CandidateSchoolDTO Get(int highSchoolID, int candidateID);
        CandidateSchoolResponse Get(QuerySettings settings);
    }
}
