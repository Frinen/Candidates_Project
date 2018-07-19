using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface IOptionsService
    {
        void Create(int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice);
        void Update(int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice);
        void Remove(int candidateID);
        Options Display(int candidateID);
        List<Options> Display();
    }
}
