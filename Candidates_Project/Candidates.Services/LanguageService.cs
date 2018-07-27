using Candidates.Library;
using Candidates.Models.Context;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using AutoMapper;
using Candidates.Mappers;

namespace Candidates.Services
{
    public class LanguageService : ILanguageService
    {
        private CandidatesContext _context;
        public LanguageService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(LanguageShortDTO language)
        {
            _context.Database.EnsureCreated();
            var _language = Mapper.Map<LanguageShortDTO, Language>(language);
            _context.Languages.Add(_language);
            _context.SaveChanges();
        }
        public void Update(int id, LanguageShortDTO language)
        {
            var _language = LanguageMapper.DtoToModel(id, language);
            _context.Languages.Update(_language);
            _context.SaveChanges();
        }
        public void Remove( int id)
        {
            var language = _context.Languages.Find(id);
            if (language != null)
            {
                _context.Languages.Remove(language);
                _context.SaveChanges();
            }
        }
        public LanguageDTO Get( int id)
        {
            var language = _context.Languages.Find(id);
            var languageDTO = Mapper.Map<Language, LanguageDTO>(language);
            return languageDTO;
        }
        public List<LanguageDTO> Get(QuerySettings settings)
        {
            var languages = new List<Language>();
            foreach (var l in _context.Languages)
                languages.Add(l);
            var languagesRange = languages.GetRange((settings.page - 1) * settings.pageSize, settings.pageSize);
            var languagesDTO = Mapper.Map<List<Language>, List<LanguageDTO>>(languagesRange);
            return languagesDTO;
        }
    }
}