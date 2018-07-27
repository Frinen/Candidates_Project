using AutoMapper;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Mappers
{
    public static class CandidateSchoolMapper
    {
        public static CandidateSchool DtoToModel(int highSchoolID, int candidateID, CandidateSchoolShortDTO candidateSchool)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CandidateSchoolShortDTO, CandidateSchool>()
                .ForMember(destination => destination.CandidateID, opts => opts.UseValue(candidateID))
                .ForMember(destination => destination.HighSchoolID, opts => opts.UseValue(highSchoolID));
            });
            IMapper mapper = config.CreateMapper();
            var _candidateSchool = mapper.Map<CandidateSchoolShortDTO, CandidateSchool>(candidateSchool);
            return _candidateSchool;
        }
    }
}
