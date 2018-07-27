using AutoMapper;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Mappers
{
    public static class SkillMapper
    {
        public static Skill DtoToModel(int id, SkillShortDTO skill)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SkillShortDTO, Skill>()
                .ForMember(destination => destination.ID, opts => opts.UseValue(id));
            });
            IMapper mapper = config.CreateMapper();
            var _skill = mapper.Map<SkillShortDTO, Skill>(skill);
            return _skill;
        }
    }
}
