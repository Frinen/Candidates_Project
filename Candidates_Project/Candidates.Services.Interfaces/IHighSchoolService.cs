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
    public interface IHighSchoolService
    {
        void CreateAsync(HighSchoolShortDTO highSchoolDTO);
        void UpdateAsync(HighSchoolDTO highSchoolDTO);
        void RemoveAsync(int id);
        Task<HighSchoolDTO> GetAsync(int id);
        PageResponse<HighSchoolDTO> Get(QuerySettings settings);
    }
}
