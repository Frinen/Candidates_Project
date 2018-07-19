﻿using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class LanguageService : ILanguageService
    {
        CandidatesContext context;
        public LanguageService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create( string name)
        {
            context.Database.EnsureCreated();
            var language = new Language { Name = name};
            context.Languages.Add(language);
            context.SaveChanges();
        }
        public void Update(int id, string name)
        {
            var language = new Language { ID = id, Name = name };
            context.Languages.Update(language);
            context.SaveChanges();
        }
        public void Remove( int id)
        {
            var language = context.Languages.Find(id);
            if (language != null)
            {
                context.Languages.Remove(language);
                context.SaveChanges();
            }
        }
        public Language Display( int id)
        {
            var language = context.Languages.Find(id);
            return language;
            
        }
        public List<Language> Display()
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
