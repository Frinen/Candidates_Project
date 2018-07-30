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
using Candidates.Responses;

namespace Candidates.Services
{
    
    public class CandidateLanguageService: ICandidateLanguageService
    {
        private CandidatesContext _context;
        public CandidateLanguageService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create( CandidateLanguageDTO candidateLanguageDTO)
        {
            _context.Database.EnsureCreated();
            var candidateLanguage = Mapper.Map<CandidateLanguageDTO, CandidateLanguage> (candidateLanguageDTO);
            _context.CandidateLanguages.Add(candidateLanguage);
            _context.SaveChanges();
        }
        public void Update( CandidateLanguageDTO candidateLanguageDTO)
        {
            var сandidateLanguage = Mapper.Map<CandidateLanguageDTO, CandidateLanguage>(candidateLanguageDTO);
            _context.CandidateLanguages.Update(сandidateLanguage);
            _context.SaveChanges();
        }
        public void Remove( int languageID, int candidateID)
        {
            var candidateLanguage = _context.CandidateLanguages.Find(languageID, candidateID);
            if (candidateLanguage != null)
            {
                _context.CandidateLanguages.Remove(candidateLanguage);
                _context.SaveChanges();
            }
        }
        public CandidateLanguageDTO Get( int languageID, int candidateID)
        {
            var candidateLanguage = _context.CandidateLanguages.Find(languageID, candidateID);
            var candidateLanguageDTO = Mapper.Map<CandidateLanguage, CandidateLanguageDTO>(candidateLanguage);
            return candidateLanguageDTO;
        }
        public CandidateLanguageResponse Get(QuerySettings settings)
        {
            var response = new CandidateLanguageResponse();
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.CandidateLanguages.Count())
            {
                IEnumerable<CandidateLanguage> candidatesLanguagePage = _context.CandidateLanguages.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                var candidatesLanguagePageDTO = Mapper.Map<IEnumerable<CandidateLanguage>, IEnumerable<CandidateLanguageDTO>>(candidatesLanguagePage);
                response.List = candidatesLanguagePageDTO;
                response.PageCount = _context.CandidateLanguages.Count() / settings.PageSize;
                response.ItemCount = _context.CandidateLanguages.Count();
                response.Message = "Ok";
            }
            else
            {
                response.Message = $" Incorrect page or item count, max item count: { _context.CandidateLanguages.Count() }";
                response.ItemCount = _context.CandidateLanguages.Count();
            }
            return response;
        }
    }
}
