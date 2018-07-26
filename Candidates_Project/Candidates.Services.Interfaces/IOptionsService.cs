using Candidates.Library;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface IOptionsService
    {
        void Create(OptionsDTO options);
        void Update(int candidateID, OptionsShortDTO options);
        void Remove(int candidateID);
        OptionsDTO Get(int candidateID);
        IQueryable<OptionsDTO> Get(QuerySettings settings);
    }
}
