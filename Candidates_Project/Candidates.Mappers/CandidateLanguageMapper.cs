using AutoMapper;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Mappers
{
    public static class CandidateLanguageMapper
    {
        public static CandidateLanguage DtoToModel(int languageID, int candidateID, CandidateLanguageShortDTO candidateLanguage)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CandidateLanguageShortDTO, CandidateLanguage>()
                .ForMember(destination => destination.CandidateID, opts => opts.UseValue(candidateID))
                .ForMember(destination => destination.LanguageID, opts => opts.UseValue(languageID));
            });
            IMapper mapper = config.CreateMapper();
            var _candidateLanguage = mapper.Map<CandidateLanguageShortDTO, CandidateLanguage>(candidateLanguage);
            return _candidateLanguage;
        }
    }
}
