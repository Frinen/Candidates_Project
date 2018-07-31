using Candidates.Models.Context;
using Candidates.Models.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidates.Library
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<CandidatesContext>();
            context.Database.EnsureCreated();
            if (!context.Accounts.Any())
            {
                context.Accounts.Add(new Account() { Login = "admin", Password = "admin", Role = "admin" });
                context.Accounts.Add(new Account() { Login = "hr", Password = "hr", Role = "hr" });
                context.SaveChanges();
            }
        }
    }
}
