using Candidates.Services;
using Candidates.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Connections
{
    public class ServiceManager
    {
        public static void AddAddTransient(IServiceCollection services)
        {
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<ICandidateLanguageService, CandidateLanguageService>();
            services.AddTransient<ICandidateSchoolService, CandidateSchoolService>();
            services.AddTransient<ICandidateSkillService, CandidateSkillService>();
            services.AddTransient<IHighSchoolService, HighSchoolService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<IOptionsService, OptionsService>();
            services.AddTransient<ISkillService, SkillService>();
        }
    }
}
