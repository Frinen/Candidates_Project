﻿using AutoMapper;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;

namespace Candidates.Mappers
{
    public static class CandidateMapper
    {
        
        public static Candidate DtoToModel(CandidateDTO person, int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CandidateDTO, Candidate>()
                .ForMember(destination => destination.ID, opts => opts.UseValue(id));
            });
            IMapper mapper = config.CreateMapper();
            var candidate = mapper.Map<CandidateDTO, Candidate>(person);
            return candidate;
        }
    }
}
