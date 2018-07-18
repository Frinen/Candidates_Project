using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class HighSchoolService
    {
        static public void Create(CandidatesContext context, string name)
        {
            context.Database.EnsureCreated();
            var school = new HighSchool { Name = name };
            context.HighSchools.Add(school);
            context.SaveChanges();
        }
        public static void Update(CandidatesContext context, int id, Skill skill)
        {



        }
        public static void Remove(CandidatesContext context, int id)
        {
            var highschool = context.HighSchools.Find(id);
            if (highschool != null)
            { 
                context.HighSchools.Remove(highschool);
                context.SaveChanges();
            }
        }
        public static HighSchool Display(CandidatesContext context, int id)
        {
            var highschool = context.HighSchools.Find(id);
            if (highschool != null)
                return highschool;
            else
                return null;
        }
    }
}
