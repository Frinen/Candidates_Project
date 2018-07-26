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
    public class OptionsService : IOptionsService
    {
        CandidatesContext _context;
        public OptionsService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(OptionsDTO options)
        {
            _context.Database.EnsureCreated();
            var _options = new Options {CandidateID = options.CandidateID, CanWorkRemotly = options.CanWorkRemotly, CanRelocate = options.CanRelocate, CanWorkInTheOffice = options.CanWorkInTheOffice};
            _context.Options.Add(_options);
            _context.SaveChanges();
        }
        public void Update( int candidateID, OptionsShortDTO options) 
        {
            var _options = new Options { CandidateID = candidateID, CanWorkRemotly = options.CanWorkRemotly, CanRelocate = options.CanRelocate, CanWorkInTheOffice = options.CanWorkInTheOffice};
            _context.Options.Update(_options);
            _context.SaveChanges();
        }
        public void Remove( int candidateID)
        {
            var options = _context.Options.Find(candidateID);
            if (options != null)
            {
                _context.Options.Remove(options);
                _context.SaveChanges();
            }
        }
        public OptionsDTO Get( int candidateID)
        {
            var options = _context.Options.Include(c => c.CandidateID).Select(c => new OptionsDTO()
            {
                CandidateID = c.CandidateID,
                CanRelocate = c.CanRelocate,
                CanWorkInTheOffice = c.CanWorkInTheOffice,
                CanWorkRemotly = c.CanWorkRemotly
            }).SingleOrDefault(c => c.CandidateID == candidateID);
            return options;
        }
        public IQueryable<OptionsDTO> Get()
        {
            var options = from c in _context.Options
                              select new OptionsDTO()
                              {
                                  CandidateID = c.CandidateID,
                                  CanRelocate = c.CanRelocate,
                                  CanWorkInTheOffice = c.CanWorkInTheOffice,
                                  CanWorkRemotly = c.CanWorkRemotly
                              };
            return options;
        }
    }
}
