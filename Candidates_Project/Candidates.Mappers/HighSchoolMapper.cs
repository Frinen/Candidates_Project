using AutoMapper;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Mappers
{
    public static class HighSchoolMapper
    {
        public static HighSchool DtoToModel(int id, HighSchoolShortDTO school)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HighSchoolShortDTO, HighSchool>()
                .ForMember(destination => destination.ID, opts => opts.UseValue(id));
            });
            IMapper mapper = config.CreateMapper();
            var _school = mapper.Map<HighSchoolShortDTO, HighSchool>(school);
            return _school;
        }
    }
}
