using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
        public CandidateLanguage Display( int languageID, int candidateID)
        {
            var candidateLanguage = context.CandidateLanguages.Find(languageID, candidateID);
            return candidateLanguage;
           
        }
        public List<CandidateLanguage> Display()
        {
            List<CandidateLanguage> candidateLanguages = new List<CandidateLanguage>();
            foreach (var candidateLanguage in context.CandidateLanguages)
            {
                candidateLanguages.Add(candidateLanguage);
            }
            return candidateLanguages;
            
        }
    }
}
