using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        public void Create(LanguageShortDTO _language)
        {
            context.Database.EnsureCreated();
            var language = new Language { Name = _language.Name};
            context.Languages.Add(language);
            context.SaveChanges();
        }
        public void Update(int id, LanguageShortDTO _language)
        {
            var language = new Language { ID = id, Name = _language.Name };
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
        public LanguageDTO Get( int id)
        {
            
            var language = context.Languages.Include(c => c.Name).Select(c => new LanguageDTO()
            {
                ID = c.ID,
                Name = c.Name
            }).SingleOrDefault(c => c.ID == id);
            return language;

        }
        public IQueryable<LanguageDTO> Get()
        {
            var languages = from c in context.Languages
                              select new LanguageDTO()
                              {
                                  ID = c.ID,
                                  Name = c.Name
                              };
            return languages;
        }
    }
}
