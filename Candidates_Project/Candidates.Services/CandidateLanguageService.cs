using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;
using Candidates.Library;

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
            var _candidateLanguage = new CandidateLanguage { LanguageID = candidateLanguage.LanguageID, CandidateID = candidateLanguage.CandidateID, Level = candidateLanguage.Level };
            _context.CandidateLanguages.Add(_candidateLanguage);
            _context.SaveChanges();
        }
        public void Update( int languageID, int candidateID, CandidateLanguageShortDTO candidateLanguage)
        {
            var _сandidateLanguage = new CandidateLanguage { LanguageID = languageID, CandidateID = candidateID, Level = candidateLanguage.Level };
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
            var candidatesLanguages = _context.CandidateLanguages.Include(c => c.CandidateID).Select(c => new CandidateLanguageDTO()
            {
               CandidateID =c.CandidateID,
               LanguageID = c.LanguageID,
               Level = c.Level
            }).Where(c => c.CandidateID == candidateID);
            var candidateLanguage = candidatesLanguages.SingleOrDefault(c => c.LanguageID == languageID);
            return candidateLanguage;
        }
        public IQueryable<CandidateLanguageDTO> Get(QuerySettings settings)
        {
            var candidatesLanguages = from c in _context.CandidateLanguages
                             select new CandidateLanguageDTO()
                             {
                                 CandidateID = c.CandidateID,
                                 LanguageID = c.LanguageID,
                                 Level = c.Level
                             };
            var candidatesLanguagesRange = candidatesLanguages.Skip((settings.page - 1) * settings.pageSize).Take(settings.pageSize);
            return candidatesLanguagesRange;
        }
    }
}
