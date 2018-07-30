using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Candidates.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface IHighSchoolService
    {
        void Create(HighSchoolShortDTO highSchoolDTO);
        void Update(HighSchoolDTO highSchoolDTO);
        void Remove(int id);
        HighSchoolDTO Get(int id);
        HighSchoolResponse Get(QuerySettings settings);
    }
}
