using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
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
        public Options Display( int candidateID)
        {
            var options = context.Options.Find(candidateID);
            return options;
           
        }
        public List<Options> Display()
        {
            List<Options> options = new List<Options>();
            foreach (var option in context.Options)
            {
                options.Add(option);
            }
            return options;
        }
    }
}
