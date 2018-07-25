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
        CandidatesContext context;
        public HighSchoolService(CandidatesContext _context)
        {
            context = _context;
        }
        public void Create(HighSchoolShortDTO _highSchool)
        {
            context.Database.EnsureCreated();
            var highSchool = new HighSchool { Name = _highSchool.Name };
            context.HighSchools.Add(highSchool);
            context.SaveChanges();
        }
        public void Update(int id, HighSchoolShortDTO _highSchool)
        {
            var highSchool = new HighSchool {ID = id, Name = _highSchool.Name };
            context.HighSchools.Update(highSchool);
            context.SaveChanges();
        }
        public void Remove(int id)
        {
            var highschool = context.HighSchools.Find(id);
            if (highschool != null)
            { 
                context.HighSchools.Remove(highschool);
                context.SaveChanges();
            }
        }
        public HighSchoolDTO Get(int id)
        {
            var highschool = context.HighSchools.Include(c => c.Name).Select(c => new HighSchoolDTO()
            {
                ID = c.ID,
                Name = c.Name
            }).SingleOrDefault(c => c.ID == id);
            return highschool;
        }
        public IQueryable<HighSchoolDTO> Get()
        {
            var highSchools = from c in context.HighSchools
                                  select new HighSchoolDTO()
                                  {
                                      ID = c.ID,
                                      Name = c.Name
                                  };
            return highSchools;
        }
    }
}
