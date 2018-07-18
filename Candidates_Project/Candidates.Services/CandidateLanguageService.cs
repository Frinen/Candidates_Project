using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    
    public class CandidateLanguageService
    {
        static public void Create(CandidatesContext context, int languageID, int candidateID, string level)
        {
            context.Database.EnsureCreated();
            var candidateLanguage = new CandidateLanguage { LanguageID = languageID, CandidateID = candidateID, Level = level };
            context.CandidateLanguages.Add(candidateLanguage);
            context.SaveChanges();
        }
        public static void Update(CandidatesContext context, int languageID, int candidateID, string level)
        {
            var сandidateLanguage = new CandidateLanguage { LanguageID = languageID, CandidateID = candidateID, Level = level };
            context.CandidateLanguages.Update(сandidateLanguage);
            context.SaveChanges();


        }
        public static void Remove(CandidatesContext context, int languageID, int candidateID)
        {
            var candidateLanguage = context.CandidateLanguages.Find(languageID, candidateID);
            if (candidateLanguage != null)
            {
                context.CandidateLanguages.Remove(candidateLanguage);
                context.SaveChanges();
            }
        }
        public static CandidateLanguage Display(CandidatesContext context, int languageID, int candidateID)
        {
            var candidateLanguage = context.CandidateLanguages.Find(languageID, candidateID);
            return candidateLanguage;
           
        }
        public static List<CandidateLanguage> Display(CandidatesContext context)
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
