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
        public void Create(string name)
        {
            context.Database.EnsureCreated();
            var school = new HighSchool { Name = name };
            context.HighSchools.Add(school);
            context.SaveChanges();
        }
        public void Update(int id, string name)
        {
            var school = new HighSchool {ID = id, Name = name };
            context.HighSchools.Update(school);
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
        public HighSchoolDTO Display(int id)
        {
            var highschool = context.HighSchools.Include(c => c.Name).Select(c => new HighSchoolDTO()
            {
                ID = c.ID,
                Name = c.Name
            }).SingleOrDefault(c => c.ID == id);
            return highschool;
        }
        public IQueryable<HighSchoolDTO> Display()
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
