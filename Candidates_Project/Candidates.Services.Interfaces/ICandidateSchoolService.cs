using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateSchoolService
    {
        void Create(int highSchoolID, int candidateID, string from, string to, string degree);
        void Update(int highSchoolID, int candidateID, string from, string to, string degree);
        void Remove(int highSchoolID, int candidateID);
        CandidateSchool Display(int highSchoolID, int candidateID);
        List<CandidateSchool> Display();
    }
}
