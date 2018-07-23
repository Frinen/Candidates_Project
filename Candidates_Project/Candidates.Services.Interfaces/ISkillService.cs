using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ISkillService
    {
        void Create(string name);
        void Update(int id, string name);
        void Remove(int id);
        SkillDTO Display(int id);
        IQueryable<SkillDTO> Display();
    }
}
