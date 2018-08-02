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
using System.Threading.Tasks;

namespace Candidates.Services
{
    public class LanguageService : ILanguageService
    {
        private CandidatesContext _context;
        public LanguageService(CandidatesContext context)
        {
            _context = context;
        }
        public async void CreateAsync(LanguageShortDTO languageDTO)
        {
            await _context.Database.EnsureCreatedAsync();
            var language = Mapper.Map<LanguageShortDTO, Language>(languageDTO);
            await _context.Languages.AddAsync(language);
            _context.SaveChanges();
        }
        public async void UpdateAsync(LanguageDTO languageDTO)
        {
            var language = Mapper.Map<LanguageDTO, Language>(languageDTO);
            _context.Languages.Update(language);
            await _context.SaveChangesAsync();
        }
        public async void RemoveAsync(int id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language != null)
            {
                _context.Languages.Remove(language);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<LanguageDTO> GetAsync( int id)
        {
            var language = await _context.Languages.FindAsync(id);
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