using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ISkillService
    {
        void Create(SkillShortDTO skill);
        void Update(int id, SkillShortDTO skill);
        void Remove(int id);
        SkillDTO Get(int id);
        IQueryable<SkillDTO> Get();
    }
}
