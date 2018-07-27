using AutoMapper;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Mappers
{
    public static class CandidateSkillMapper
    {
        public static CandidateSkill DtoToModel(int skillID, int candidateID, CandidateSkillShortDTO candidateSkill)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CandidateSkillShortDTO, CandidateSkill>()
                .ForMember(destination => destination.CandidateID, opts => opts.UseValue(candidateID))
                .ForMember(destination => destination.SkillID, opts => opts.UseValue(skillID));
            });
            IMapper mapper = config.CreateMapper();
            var _candidateSkill = mapper.Map<CandidateSkillShortDTO, CandidateSkill>(candidateSkill);
            return _candidateSkill;
        }
    }
}
