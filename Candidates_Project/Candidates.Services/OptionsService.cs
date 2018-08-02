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
using System.Threading.Tasks;

namespace Candidates.Services
{
    public class OptionsService : IOptionsService
    {
        CandidatesContext _context;
        public OptionsService(CandidatesContext context)
        {
            _context = context;
        }
        public async void CreateAsync(OptionsDTO optionsDTO)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var options = Mapper.Map<OptionsDTO, Options>(optionsDTO);
                await _context.Options.AddAsync(options);
                await _context.SaveChangesAsync();
            }
        }
        public async void UpdateAsync(OptionsDTO optionsDTO) 
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var options = Mapper.Map<OptionsDTO, Options>(optionsDTO);
                _context.Options.Update(options);
                await _context.SaveChangesAsync();
            }
        }
        public async void RemoveAsync( int candidateID)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var options = await _context.Options.FindAsync(candidateID);
                if (options != null)
                {
                    _context.Options.Remove(options);
                    await _context.SaveChangesAsync();
                }
            }
        }
        public async Task<OptionsDTO> GetAsync( int candidateID)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var options = await _context.Options.FindAsync(candidateID);
                var optionsDTO = Mapper.Map<Options, OptionsDTO>(options);
                return optionsDTO;
            }
            else
            {
                return null;
            }
        }
        public PageResponse<OptionsDTO> Get(QuerySettings settings)
        {
            var response = new PageResponse<OptionsDTO>();
            if (_context.Database.EnsureCreated())
            {
                if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.Languages.Count())
                {
                    IEnumerable<Options> optionsPage = _context.Options.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                    var optionsPageDTO = Mapper.Map<IEnumerable<Options>, IEnumerable<OptionsDTO>>(optionsPage);
                    response.List = optionsPageDTO;
                    response.PageCount = _context.Options.Count() / settings.PageSize;
                    response.ItemCount = _context.Options.Count();
                    // response.Message = "Ok";
                }
                else
                {
                    // response.Message = $" Incorrect page or item count, max item count: { _context.Languages.Count() }";
                    response.ItemCount = _context.Options.Count();
                }
            }
            else
            {
                // response.Message = $" Incorrect page or item count, max item count: { _context.Languages.Count() }";
                response.ItemCount = _context.Options.Count();
            }
            return response;
        }
    }
}
