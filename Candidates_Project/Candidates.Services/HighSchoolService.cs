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
    public class HighSchoolService : IHighSchoolService
    {
        private CandidatesContext _context;
        public HighSchoolService(CandidatesContext context)
        {
           _context = context;
        }
        public void Create(HighSchoolShortDTO highSchool)
        {
            _context.Database.EnsureCreated();
            var _highSchool = Mapper.Map<HighSchoolShortDTO, HighSchool>(highSchool);
            _context.HighSchools.Add(_highSchool);
            _context.SaveChanges();
        }
        public void Update(int id, HighSchoolShortDTO highSchool)
        {
            var _highSchool = HighSchoolMapper.DtoToModel(id, highSchool);
            _context.HighSchools.Update(_highSchool);
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
            foreach (var c in _context.HighSchools)
                highSchools.Add(c);
            var highSchoolsRange = highSchools.GetRange((settings.page - 1) * settings.pageSize, settings.pageSize);
            var highSchoolsDTO = Mapper.Map<List<HighSchool>, List<HighSchoolDTO>>(highSchoolsRange);
            return highSchoolsDTO;
        }
    }
}
