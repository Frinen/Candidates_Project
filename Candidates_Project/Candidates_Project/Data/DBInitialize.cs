using Candidates_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Data
{
    public class DBInitialize
    {
        public static void Initialize(CandidatesContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Candidates.Any())
            {
                return;   // DB has been seeded
            }
            
        var person = new Candidate { FirstName = "Fort", LastName = "Carson", BirthDate = DateTime.Parse("2005-09-01") };
            context.Candidates.Add(person);
            context.SaveChanges();
        }
    }
}
