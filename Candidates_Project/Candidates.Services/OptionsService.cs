using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class OptionsService
    {
        static public void Create(CandidatesContext context, int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice)
        {
            context.Database.EnsureCreated();
            var options = new Options {CandidateID = candidateID, CanWorkRemotly = canWorkRemotly, CanRelocate = canRelocate, CanWorkInTheOffice = canWorkInTheOffice };
            context.Options.Add(options);
            context.SaveChanges();
        }
        public static void Update(CandidatesContext context, int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice) 
        {
            var options = new Options { CandidateID = candidateID, CanWorkRemotly = canWorkRemotly, CanRelocate = canRelocate, CanWorkInTheOffice = canWorkInTheOffice };
            context.Options.Update(options);
            context.SaveChanges();
        }
        public static void Remove(CandidatesContext context, int id)
        {
            var options = context.Options.Find(id);
            if (options != null)
            {
                context.Options.Remove(options);
                context.SaveChanges();
            }
        }
        public static Options Display(CandidatesContext context, int id)
        {
            var options = context.Options.Find(id);
            return options;
           
        }
        public static List<Options> Display(CandidatesContext context)
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
