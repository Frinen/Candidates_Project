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
        CandidatesContext context;
        public OptionsService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create(OptionsDTO _options)
        {
            context.Database.EnsureCreated();
            var options = new Options {CandidateID = _options.CandidateID, CanWorkRemotly = _options.CanWorkRemotly, CanRelocate = _options.CanRelocate, CanWorkInTheOffice = _options.CanWorkInTheOffice};
            context.Options.Add(options);
            context.SaveChanges();
        }
        public void Update( int candidateID, OptionsShortDTO _options) 
        {
            var options = new Options { CandidateID = candidateID, CanWorkRemotly = _options.CanWorkRemotly, CanRelocate = _options.CanRelocate, CanWorkInTheOffice = _options.CanWorkInTheOffice};
            context.Options.Update(options);
            context.SaveChanges();
        }
        public void Remove( int candidateID)
        {
            var options = context.Options.Find(candidateID);
            if (options != null)
            {
                context.Options.Remove(options);
                context.SaveChanges();
            }
        }
        public OptionsDTO Get( int candidateID)
        {
            var options = context.Options.Include(c => c.CandidateID).Select(c => new OptionsDTO()
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
            var options = from c in context.Options
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
