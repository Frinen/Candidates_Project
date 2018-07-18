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
        public static void Update(CandidatesContext context, int id, Language candidate)
        {



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
            if (language != null)
                return language;
            else
                return null;
        }
    }
}
