﻿using Candidates.Library;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Services.Interfaces
{
    public interface ILanguageService
    {
        void Create(LanguageShortDTO language);
        void Update(int id, LanguageShortDTO language);
        void Remove(int id);
        LanguageDTO Get(int id);
        List<LanguageDTO> Get(QuerySettings settings);
    }
}
