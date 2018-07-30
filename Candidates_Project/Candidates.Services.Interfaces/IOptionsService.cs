using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface IOptionsService
    {
        void Create(OptionsDTO optionsDTO);
        void Update(OptionsDTO optionsDTO);
        void Remove(int candidateID);
        OptionsDTO Get(int candidateID);
        PageResponse<OptionsDTO> Get(QuerySettings settings);
    }
}
