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
        public void Create(int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice)
        {
            context.Database.EnsureCreated();
            var options = new Options {CandidateID = candidateID, CanWorkRemotly = canWorkRemotly, CanRelocate = canRelocate, CanWorkInTheOffice = canWorkInTheOffice };
            context.Options.Add(options);
            context.SaveChanges();
        }
        public void Update( int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice) 
        {
            var options = new Options { CandidateID = candidateID, CanWorkRemotly = canWorkRemotly, CanRelocate = canRelocate, CanWorkInTheOffice = canWorkInTheOffice };
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
        public OptionsDTO Display( int candidateID)
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
        public IQueryable<OptionsDTO> Display()
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
