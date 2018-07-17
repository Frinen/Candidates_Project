using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class OptionsService
    {
        static public void AddOptions(CandidatesContext context, int candidateID, bool canWorkRemotly, bool canRelocate, bool canWorkInTheOffice)
        {
            context.Database.EnsureCreated();
            var options = new Options {CandidateID = candidateID, CanWorkRemotly = canWorkRemotly, CanRelocate = canRelocate, CanWorkInTheOffice = canWorkInTheOffice };
            context.Options.Add(options);
            context.SaveChanges();
        }
        public static void ChangeOptions(CandidatesContext context, int id, Options options)
        {



        }
        public static void DeleteOptions(CandidatesContext context, int id)
        {
            var options = context.Options.Find(id);
            if (options != null)
            {
                context.Options.Remove(options);
                context.SaveChanges();
            }
        }
        public static Options VievOptions(CandidatesContext context, int id)
        {
            var options = context.Options.Find(id);
            if (options != null)
                return options;
            else
                return null;
        }
    }
}
