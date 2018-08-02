using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidates.Services.Interfaces
{
    public interface IOptionsService
    {
        void CreateAsync(OptionsDTO optionsDTO);
        void UpdateAsync(OptionsDTO optionsDTO);
        void RemoveAsync(int candidateID);
        Task<OptionsDTO> GetAsync(int candidateID);
        PageResponse<OptionsDTO> Get(QuerySettings settings);
    }
}
