using AutoMapper;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Mappers
{
    public static class MapperManager
    {
        public static void Initiaize()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<CandidateDTO, Candidate>();
                cfg.CreateMap<CandidateDetailsDTO, Candidate>();
                cfg.CreateMap<Candidate, CandidateDetailsDTO>();
                cfg.CreateMap<Candidate, CandidateShortDTO>();


                cfg.CreateMap<CandidateLanguage, CandidateLanguageDTO>();
                cfg.CreateMap<CandidateLanguageDTO, CandidateLanguage>();

                cfg.CreateMap<CandidateSchoolDTO, CandidateSchool>();
                cfg.CreateMap<CandidateSchool, CandidateSchoolDTO>();

                cfg.CreateMap<CandidateSkillDTO, CandidateSkill>();
                cfg.CreateMap<CandidateSkill, CandidateSkillDTO>();

                cfg.CreateMap<HighSchoolShortDTO, HighSchool>();
                cfg.CreateMap<HighSchool, HighSchoolDTO>();
                cfg.CreateMap<HighSchoolDTO, HighSchool>();

                cfg.CreateMap<LanguageShortDTO, Language>();
                cfg.CreateMap<Language, LanguageDTO>();
                cfg.CreateMap<LanguageDTO, Language>();

                cfg.CreateMap<OptionsDTO, Options>();
                cfg.CreateMap<Options, OptionsDTO>();

                cfg.CreateMap<SkillShortDTO, Skill>();
                cfg.CreateMap<Skill, SkillDTO>();
                cfg.CreateMap<SkillDTO, Skill>();

                cfg.CreateMap<Account, AccountDTO>();
                cfg.CreateMap<Account, AccountShortDTO>();
                cfg.CreateMap<AccountDTO, Account>();
            });
        }
    }
}
