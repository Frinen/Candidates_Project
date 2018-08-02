using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Candidates.Library;
using Candidates.Models.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;

namespace Candidates.Services
{
    
    public class CandidateLanguageService: ICandidateLanguageService
    {
        private CandidatesContext _context;
        public CandidateLanguageService(CandidatesContext context)
        {
            _context = context;
        }
        public async void CreateAsync( CandidateLanguageDTO candidateLanguageDTO)
        {
            await _context.Database.EnsureCreatedAsync();
            var candidateLanguage = Mapper.Map<CandidateLanguageDTO, CandidateLanguage> (candidateLanguageDTO);
            await _context.CandidateLanguages.AddAsync(candidateLanguage);
            await _context.SaveChangesAsync();
        }
        public async void UpdateAsync( CandidateLanguageDTO candidateLanguageDTO)
        {
            var сandidateLanguage = Mapper.Map<CandidateLanguageDTO, CandidateLanguage>(candidateLanguageDTO);
            _context.CandidateLanguages.Update(сandidateLanguage);
            await _context.SaveChangesAsync();
        }
        public async void RemoveAsync( int languageID, int candidateID)
        {
            var candidateLanguage = await _context.CandidateLanguages.FindAsync(languageID, candidateID);
            if (candidateLanguage != null)
            {
                _context.CandidateLanguages.Remove(candidateLanguage);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<CandidateLanguageDTO> GetAsync( int languageID, int candidateID)
        {
            var candidateLanguage = await _context.CandidateLanguages.FindAsync(languageID, candidateID);
            var candidateLanguageDTO = Mapper.Map<CandidateLanguage, CandidateLanguageDTO>(candidateLanguage);
            return candidateLanguageDTO;
        }
        public PageResponse<CandidateLanguageDTO> Get(QuerySettings settings)
        {
            var response = new PageResponse<CandidateLanguageDTO>();
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.CandidateLanguages.Count())
            {
                IEnumerable<CandidateLanguage> candidatesLanguagePage = _context.CandidateLanguages.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                var candidatesLanguagePageDTO = Mapper.Map<IEnumerable<CandidateLanguage>, IEnumerable<CandidateLanguageDTO>>(candidatesLanguagePage);
                response.List = candidatesLanguagePageDTO;
                response.PageCount = _context.CandidateLanguages.Count() / settings.PageSize;
                response.ItemCount = _context.CandidateLanguages.Count();
               // response.Message = "Ok";
            }
            else
            {
                //response.Message = $" Incorrect page or item count, max item count: { _context.CandidateLanguages.Count() }";
                response.ItemCount = _context.CandidateLanguages.Count();
            }
            return response;
        }
    }
}
