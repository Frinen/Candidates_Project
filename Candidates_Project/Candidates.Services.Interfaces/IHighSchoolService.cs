using Candidates.Library;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface IHighSchoolService
    {
        void Create(HighSchoolShortDTO highSchool);
        void Update(int id, HighSchoolShortDTO highSchool);
        void Remove(int id);
        HighSchoolDTO Get(int id);
        IQueryable<HighSchoolDTO> Get(QuerySettings settings);
    }
}
