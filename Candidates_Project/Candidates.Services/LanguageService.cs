using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class LanguageService
    {
        static public void Create(CandidatesContext context, string name)
        {
            context.Database.EnsureCreated();
            var language = new Language { Name = name};
            context.Languages.Add(language);
            context.SaveChanges();
        }
        public static void Update(CandidatesContext context, int id, string name)
        {
            var language = new Language { ID = id, Name = name };
            context.Languages.Update(language);
            context.SaveChanges();
        }
        public static void Remove(CandidatesContext context, int id)
        {
            var language = context.Languages.Find(id);
            if (language != null)
            {
                context.Languages.Remove(language);
                context.SaveChanges();
            }
        }
        public static Language Display(CandidatesContext context, int id)
        {
            var language = context.Languages.Find(id);
            return language;
            
        }
        public static List<Language> Display(CandidatesContext context)
        {
            List<Language> languages = new List<Language>();
            foreach (var language in context.Languages)
            {
                languages.Add(language);
            }
            return languages;
        }
    }
}
