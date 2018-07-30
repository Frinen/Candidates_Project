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
        public PageResponse<LanguageDTO> Get(QuerySettings settings)
        {
            var response = new PageResponse<LanguageDTO>();
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.Languages.Count())
            {
                IEnumerable<Language> languagesPage = _context.Languages.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                var languagesPageDTO = Mapper.Map<IEnumerable<Language>, IEnumerable<LanguageDTO>>(languagesPage);
                response.List = languagesPageDTO;
                response.PageCount = _context.Languages.Count() / settings.PageSize;
                response.ItemCount = _context.Languages.Count();
               // response.Message = "Ok";
            }
            else
            {
               // response.Message = $" Incorrect page or item count, max item count: { _context.Languages.Count() }";
                response.ItemCount = _context.Languages.Count();
            }
            return response;
        }
    }
}