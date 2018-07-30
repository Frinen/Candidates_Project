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

namespace Candidates.Services
{
    public class LanguageService : ILanguageService
    {
        private CandidatesContext _context;
        public LanguageService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(LanguageShortDTO languageDTO)
        {
            _context.Database.EnsureCreated();
            var language = Mapper.Map<LanguageShortDTO, Language>(languageDTO);
            _context.Languages.Add(language);
            _context.SaveChanges();
        }
        public void Update(LanguageDTO languageDTO)
        {
            var language = Mapper.Map<LanguageDTO, Language>(languageDTO);
            _context.Languages.Update(language);
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
            if ((settings.page - 1) * settings.pageSize + settings.pageSize <= languages.Count)
            {
                var languagesPage = languages.GetRange((settings.page - 1) * settings.pageSize, settings.pageSize);
                var languagesPageDTO = Mapper.Map<List<Language>, List<LanguageDTO>>(languagesPage);
                return languagesPageDTO;
            }
            else
            {
                var languagesPageDTO = Mapper.Map<List<Language>, List<LanguageDTO>>(languages);
                return languagesPageDTO;
            }
        }
    }
}