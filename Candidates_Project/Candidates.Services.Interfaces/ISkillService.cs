using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ISkillService
    {
        void Create(SkillShortDTO skillDTO);
        void Update(SkillDTO skillDTO);
        void Remove(int id);
        SkillDTO Get(int id);
        PageResponse<SkillDTO> Get(QuerySettings settings);
    }
}
