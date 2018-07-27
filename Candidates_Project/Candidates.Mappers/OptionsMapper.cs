using AutoMapper;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Mappers
{
    public static class OptionsMapper
    {
        public static Options DtoToModel(int id, OptionsShortDTO options)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OptionsShortDTO, Options>()
                .ForMember(destination => destination.ID, opts => opts.UseValue(id));
            });
            IMapper mapper = config.CreateMapper();
            var _options = mapper.Map<OptionsShortDTO, Options>(options);
            return _options;
        }
    }
}
