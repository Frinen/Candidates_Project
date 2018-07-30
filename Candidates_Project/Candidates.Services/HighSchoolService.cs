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
        public List<HighSchoolDTO> Get(QuerySettings settings)
        {
            var highSchools = new List<HighSchool>();
            foreach (var h in _context.HighSchools)
                highSchools.Add(h);
            if ((settings.Page - 1) * settings.PageSize + settings.PageSize <= highSchools.Count)
            {
                var highSchoolsPage = highSchools.GetRange((settings.Page - 1) * settings.PageSize, settings.PageSize);
                var highSchoolsPageDTO = Mapper.Map<List<HighSchool>, List<HighSchoolDTO>>(highSchoolsPage);
                return highSchoolsPageDTO;
            }
            else
            {
                var highSchoolsPageDTO = Mapper.Map<List<HighSchool>, List<HighSchoolDTO>>(highSchools);
                return highSchoolsPageDTO;
            }
        }
    }
}
