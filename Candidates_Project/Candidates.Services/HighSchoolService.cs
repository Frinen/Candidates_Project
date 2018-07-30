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
    public class HighSchoolService : IHighSchoolService
    {
        private CandidatesContext _context;
        public HighSchoolService(CandidatesContext context)
        {
           _context = context;
        }
        public void Create(HighSchoolShortDTO highSchoolDTO)
        {
            _context.Database.EnsureCreated();
            var highSchool = Mapper.Map<HighSchoolShortDTO, HighSchool>(highSchoolDTO);
            _context.HighSchools.Add(highSchool);
            _context.SaveChanges();
        }
        public void Update( HighSchoolDTO highSchoolDTO)
        {
            var highSchool = Mapper.Map<HighSchoolDTO, HighSchool>(highSchoolDTO);
            _context.HighSchools.Update(highSchool);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            var highschool = _context.HighSchools.Find(id);
            if (highschool != null)
            { 
                _context.HighSchools.Remove(highschool);
                _context.SaveChanges();
            }
        }
        public HighSchoolDTO Get(int id)
        {
            var highschool = _context.HighSchools.Find(id);
            var highschoolDTO = Mapper.Map<HighSchool,HighSchoolDTO>(highschool);
            return highschoolDTO;
        }
        public PageResponse<HighSchoolDTO> Get(QuerySettings settings)
        {
            var response = new PageResponse<HighSchoolDTO>();
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
            return response;
        }
    }
}
