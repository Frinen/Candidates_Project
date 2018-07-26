using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

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
            var _highSchool = new HighSchool { Name = highSchool.Name };
            _context.HighSchools.Add(_highSchool);
            _context.SaveChanges();
        }
        public void Update(int id, HighSchoolShortDTO highSchool)
        {
            var _highSchool = new HighSchool {ID = id, Name = highSchool.Name };
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
            var highschool = _context.HighSchools.Include(c => c.Name).Select(c => new HighSchoolDTO()
            {
                ID = c.ID,
                Name = c.Name
            }).SingleOrDefault(c => c.ID == id);
            return highschool;
        }
        public IQueryable<HighSchoolDTO> GetPage(int page, int pageSize)
        {
            var highSchools = from c in _context.HighSchools
                                  select new HighSchoolDTO()
                                  {
                                      ID = c.ID,
                                      Name = c.Name
                                  };
            var highSchoolsRange = highSchools.Skip((page - 1) * pageSize).Take(pageSize);
            return highSchoolsRange;
        }
    }
}
