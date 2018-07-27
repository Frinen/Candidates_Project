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
using Candidates.Mappers;

namespace Candidates.Services
{
    
    public class CandidateLanguageService: ICandidateLanguageService
    {
        private CandidatesContext _context;
        public CandidateLanguageService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create( CandidateLanguageDTO candidateLanguage)
        {
            _context.Database.EnsureCreated();
            var _candidateLanguage = Mapper.Map<CandidateLanguageDTO, CandidateLanguage> (candidateLanguage);
            _context.CandidateLanguages.Add(_candidateLanguage);
            _context.SaveChanges();
        }
        public void Update( int languageID, int candidateID, CandidateLanguageShortDTO candidateLanguage)
        {
            var _сandidateLanguage = CandidateLanguageMapper.DtoToModel(languageID, candidateID, candidateLanguage);
            _context.CandidateLanguages.Update(_сandidateLanguage);
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
            var candidatesLanguagesRange = candidatesLanguages.GetRange((settings.page - 1) * settings.pageSize, settings.pageSize);
            var candidatesLanguagesDTO = Mapper.Map<List<CandidateLanguage>, List<CandidateLanguageDTO>>(candidatesLanguagesRange);
            return candidatesLanguagesDTO;
        }
    }
}
