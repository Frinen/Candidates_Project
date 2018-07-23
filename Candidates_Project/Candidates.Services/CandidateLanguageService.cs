using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;
namespace Candidates.Services
{
    
    public class CandidateLanguageService: ICandidateLanguageService
    {
        CandidatesContext context;
        public CandidateLanguageService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create( int languageID, int candidateID, string level)
        {
            context.Database.EnsureCreated();
            var candidateLanguage = new CandidateLanguage { LanguageID = languageID, CandidateID = candidateID, Level = level };
            context.CandidateLanguages.Add(candidateLanguage);
            context.SaveChanges();
        }
        public void Update( int languageID, int candidateID, string level)
        {
            var сandidateLanguage = new CandidateLanguage { LanguageID = languageID, CandidateID = candidateID, Level = level };
            context.CandidateLanguages.Update(сandidateLanguage);
            context.SaveChanges();


        }
        public void Remove( int languageID, int candidateID)
        {
            var candidateLanguage = context.CandidateLanguages.Find(languageID, candidateID);
            if (candidateLanguage != null)
            {
                context.CandidateLanguages.Remove(candidateLanguage);
                context.SaveChanges();
            }
        }
        public CandidateLanguageDTO Display( int languageID, int candidateID)
        {
            var candidateLanguages = context.CandidateLanguages.Include(c => c.CandidateID).Select(c => new CandidateLanguageDTO()
            {
               CandidateID =c.CandidateID,
               LanguageID = c.LanguageID,
               Level = c.Level
            }).Where(c => c.CandidateID == candidateID);
            var candidateLanguage = candidateLanguages.SingleOrDefault(c => c.LanguageID == languageID);
            return candidateLanguage;
        }
        public IQueryable<CandidateLanguageDTO> Display()
        {
            var candidateLanguages = from c in context.CandidateLanguages
                             select new CandidateLanguageDTO()
                             {
                                 CandidateID = c.CandidateID,
                                 LanguageID = c.LanguageID,
                                 Level = c.Level
                             };
            return candidateLanguages;
        }
    }
}
