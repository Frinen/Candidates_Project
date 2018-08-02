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
    public interface ISkillService
    {
        void CreateAsync(SkillShortDTO skillDTO);
        void UpdateAsync(SkillDTO skillDTO);
        void RemoveAsync(int id);
        Task<SkillDTO> GetAsync(int id);
        PageResponse<SkillDTO> Get(QuerySettings settings);
    }
}
