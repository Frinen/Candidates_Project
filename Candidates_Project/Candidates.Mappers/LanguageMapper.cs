using AutoMapper;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Mappers
{
    public static class LanguageMapper
    {
        public static Language DtoToModel(int id, LanguageShortDTO language)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LanguageShortDTO, Language>()
                .ForMember(destination => destination.ID, opts => opts.UseValue(id));
            });
            IMapper mapper = config.CreateMapper();
            var _language = mapper.Map<LanguageShortDTO, Language>(language);
            return _language;
        }
    }
}
