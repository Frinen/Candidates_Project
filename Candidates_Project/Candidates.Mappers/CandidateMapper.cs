using AutoMapper;
using Candidates.Models.Models;
using System;

namespace Candidates.Mappers
{
    public static class CandidateMapper
    {
        public static Candidate DtoToModel(CandidateDTO person)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CandidateDTO, Candidate>(); });
            IMapper mapper = config.CreateMapper();
            var candidate = mapper.Map<CandidateDTO, Candidate>(person);
            return candidate;
        }
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
        public static CandidateDetailsDTO ModelToDto(Candidate candidate)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Candidate, CandidateDetailsDTO>(); });
            IMapper mapper = config.CreateMapper();
            var candidateDTO = mapper.Map<Candidate, CandidateDetailsDTO>(candidate);
            return (candidateDTO);
        }
        public static CandidateShortDTO ModelToShortDto(Candidate candidate)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Candidate, CandidateShortDTO>(); });
            IMapper mapper = config.CreateMapper();
            var candidateDTO = mapper.Map<Candidate, CandidateShortDTO>(candidate);
            return (candidateDTO);
        }
    }
}
