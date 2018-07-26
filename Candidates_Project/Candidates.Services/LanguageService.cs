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
        private CandidatesContext _context;
        public LanguageService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(LanguageShortDTO language)
        {
            _context.Database.EnsureCreated();
            var _language = new Language { Name = language.Name};
            _context.Languages.Add(_language);
            _context.SaveChanges();
        }
        public void Update(int id, LanguageShortDTO language)
        {
            var _language = new Language { ID = id, Name = language.Name };
            _context.Languages.Update(_language);
            _context.SaveChanges();
        }
        public void Remove( int id)
        {
            var language = _context.Languages.Find(id);
            if (language != null)
            {
                _context.Languages.Remove(language);
                _context.SaveChanges();
            }
        }
        public LanguageDTO Get( int id)
        {
            
            var language = _context.Languages.Include(c => c.Name).Select(c => new LanguageDTO()
            {
                ID = c.ID,
                Name = c.Name
            }).SingleOrDefault(c => c.ID == id);
            return language;

        }
        public IQueryable<LanguageDTO> GetPage(int page, int pageSize)
        {
            var languages = from c in _context.Languages
                              select new LanguageDTO()
                              {
                                  ID = c.ID,
                                  Name = c.Name
                              };
            var languagesRange = languages.Skip((page - 1) * pageSize).Take(pageSize);
            return languagesRange;
        }
    }
}