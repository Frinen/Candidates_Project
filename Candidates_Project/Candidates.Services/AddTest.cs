using Candidates.Models.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Candidates.Services
{
   /* public class AddTest
    {
        public static void AddCandidate(IWebHost host, string firstName, string lastName, string birthDate, string sex, string phoneNumber, string email, string skype)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

               // try
               // {
                    var context = services.GetRequiredService<CandidatesContext>();
                    AddEntity.AddCandidate(context, firstName, lastName, birthDate, sex, phoneNumber, email, skype);
              //  }
              //  catch (Exception ex)
              /*  {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
        }
        
    }*/
}
