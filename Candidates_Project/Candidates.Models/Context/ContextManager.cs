using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Models.Context
{
    public class ContextManager
    {
        static public void CreateContext(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CandidatesContext>(options =>
      options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
