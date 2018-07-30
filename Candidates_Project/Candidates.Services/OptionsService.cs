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
using Candidates.Responses;

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
        public OptionsResponse Get(QuerySettings settings)
        {
            var response = new OptionsResponse();
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.Languages.Count())
            {
                IEnumerable<Options> optionsPage = _context.Options.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                var optionsPageDTO = Mapper.Map<IEnumerable<Options>, IEnumerable<OptionsDTO>>(optionsPage);
                response.List = optionsPageDTO;
                response.PageCount = _context.Options.Count() / settings.PageSize;
                response.ItemCount = _context.Options.Count();
                response.Message = "Ok";
            }
            else
            {
                response.Message = $" Incorrect page or item count, max item count: { _context.Languages.Count() }";
                response.ItemCount = _context.Options.Count();
            }
            return response;
        }
    }
}
