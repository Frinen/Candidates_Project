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
        public List<CandidateLanguageDTO> Get(QuerySettings settings)
        {
            var candidatesLanguages = new List<CandidateLanguage>();
            foreach (var c in _context.CandidateLanguages)
                candidatesLanguages.Add(c);
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= candidatesLanguages.Count)
            {
                var candidatesLanguagesPage = candidatesLanguages.GetRange((settings.Page - 1) * settings.PageSize, settings.PageSize);
                var candidatesLanguagesPageDTO = Mapper.Map<List<CandidateLanguage>, List<CandidateLanguageDTO>>(candidatesLanguagesPage);
                return candidatesLanguagesPageDTO;
            }
            else
            {
                var candidatesLanguagesPageDTO = Mapper.Map<List<CandidateLanguage>, List<CandidateLanguageDTO>>(candidatesLanguages);
                return candidatesLanguagesPageDTO;
            }
        }
    }
}
