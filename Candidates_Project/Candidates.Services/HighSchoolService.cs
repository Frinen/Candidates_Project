using Candidates.Models.Context;
using Candidates.Models.Models;
using Candidates.Services.Interfaces;
using System;
using System.Collections.Generic;
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
        public HighSchool Display(int id)
        {
            var highschool = context.HighSchools.Find(id);
            return highschool;
            
        }
        public List<HighSchool> Display()
        {
            List<HighSchool> highSchools = new List<HighSchool>();
            foreach (var highSchool in context.HighSchools)
            {
                highSchools.Add(highSchool);
            }
            return highSchools;
        }
    }
}
