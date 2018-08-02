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
    public class HighSchoolService : IHighSchoolService
    {
        private CandidatesContext _context;
        public HighSchoolService(CandidatesContext context)
        {
           _context = context;
        }
        public async void CreateAsync(HighSchoolShortDTO highSchoolDTO)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var highSchool = Mapper.Map<HighSchoolShortDTO, HighSchool>(highSchoolDTO);
                await _context.HighSchools.AddAsync(highSchool);
                await _context.SaveChangesAsync();
            }
        }
        public async void UpdateAsync( HighSchoolDTO highSchoolDTO)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var highSchool = Mapper.Map<HighSchoolDTO, HighSchool>(highSchoolDTO);
                _context.HighSchools.Update(highSchool);
                await _context.SaveChangesAsync();
            }
        }
        public async void RemoveAsync(int id)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var highschool = await _context.HighSchools.FindAsync(id);
                if (highschool != null)
                {
                    _context.HighSchools.Remove(highschool);
                    await _context.SaveChangesAsync();
                }
            }
        }
        public async Task<HighSchoolDTO> GetAsync(int id)
        {
            if (await _context.Database.EnsureCreatedAsync())
            {
                var highschool = await _context.HighSchools.FindAsync(id);
                var highschoolDTO = Mapper.Map<HighSchool, HighSchoolDTO>(highschool);
                return highschoolDTO;
            }
            else
                return null;
        }
        public PageResponse<HighSchoolDTO> Get(QuerySettings settings)
        {
            var response = new PageResponse<HighSchoolDTO>();
            if (_context.Database.EnsureCreated())
            {
                
                if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= _context.HighSchools.Count())
                {
                    IEnumerable<HighSchool> highSchoolsPage = _context.HighSchools.Skip((settings.Page - 1) * settings.PageSize).Take(settings.PageSize);
                    var highSchoolsPageDTO = Mapper.Map<IEnumerable<HighSchool>, IEnumerable<HighSchoolDTO>>(highSchoolsPage);
                    response.List = highSchoolsPageDTO;
                    response.PageCount = _context.HighSchools.Count() / settings.PageSize;
                    response.ItemCount = _context.HighSchools.Count();
                    //response.Message = "Ok";
                }
                else
                {
                    // response.Message = $" Incorrect page or item count, max item count: { _context.HighSchools.Count() }";
                    response.ItemCount = _context.HighSchools.Count();
                }
            }
            else
            {
                response.ItemCount = _context.HighSchools.Count();
            }
            return response;
        }
    }
}
