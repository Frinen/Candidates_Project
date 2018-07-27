using Candidates.Library;
using Candidates.Models.Context;
using Candidates.Models.DTO;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using AutoMapper;
using Candidates.Mappers;

namespace Candidates.Services
{
    public class OptionsService : IOptionsService
    {
        CandidatesContext _context;
        public OptionsService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(OptionsDTO options)
        {
            _context.Database.EnsureCreated();
            var _options = Mapper.Map<OptionsDTO, Options>(options);
            _context.Options.Add(_options);
            _context.SaveChanges();
        }
        public void Update( int candidateID, OptionsShortDTO options) 
        {
            var _options = OptionsMapper.DtoToModel(candidateID,options);
            _context.Options.Update(_options);
            _context.SaveChanges();
        }
        public void Remove( int candidateID)
        {
            var options = _context.Options.Find(candidateID);
            if (options != null)
            {
                _context.Options.Remove(options);
                _context.SaveChanges();
            }
        }
        public OptionsDTO Get( int candidateID)
        {
            var options = _context.Options.Find(candidateID);
            var optionsDTO = Mapper.Map<Options, OptionsDTO>(options);
            return optionsDTO;
        }
        public List<OptionsDTO> Get(QuerySettings settings)
        {
            var options = new List<Options>();
            foreach (var o in _context.Options)
                options.Add(o);
            var optionsRange = options.GetRange((settings.page - 1) * settings.pageSize, settings.pageSize);
            var optionsDTO = Mapper.Map<List<Options>, List<OptionsDTO>>(optionsRange);
            return optionsDTO;
        }
    }
}
