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

namespace Candidates.Services
{
    public class OptionsService : IOptionsService
    {
        CandidatesContext _context;
        public OptionsService(CandidatesContext context)
        {
            _context = context;
        }
        public void Create(OptionsDTO optionsDTO)
        {
            _context.Database.EnsureCreated();
            var options = Mapper.Map<OptionsDTO, Options>(optionsDTO);
            _context.Options.Add(options);
            _context.SaveChanges();
        }
        public void Update(OptionsDTO optionsDTO) 
        {
            var options = Mapper.Map<OptionsDTO, Options>(optionsDTO);
            _context.Options.Update(options);
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
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= options.Count)
            {
                var optionsPage = options.GetRange((settings.Page - 1) * settings.PageSize, settings.PageSize);
                var optionsPageDTO = Mapper.Map<List<Options>, List<OptionsDTO>>(optionsPage);
                return optionsPageDTO;
            }
            else
            {
                var optionsPageDTO = Mapper.Map<List<Options>, List<OptionsDTO>>(options);
                return optionsPageDTO;
            }
        }
    }
}
