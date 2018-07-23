using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ICandidateService
    {
        void Create(string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype);
        void Update(int id, string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype);
        void Remove(int id);
        Candidate Display(int id);
        IQueryable<CandidateDTO> Display();
    }
}
