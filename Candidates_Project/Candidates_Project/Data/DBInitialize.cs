using Candidates_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Data
{
    public class DBInitialize
    {
        public static void Initialize(CandidatesContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Options.Any())
            {
                return;   // DB has been seeded
            }

           /* var person = new Candidate { FirstName = "Fort", LastName = "Carson", BirthDate = DateTime.Parse("1995-09-01"), Sex = "Male", PhoneNumber = "806855058623", Email = "FCarson@gnmail.com", Skype = "FCarson" };
            context.Candidates.Add(person);

            var options = new Options { CandidateID = 1, CanRelocate = false, CanWorkInTheOffice = true, CanWorkRemotly = true };
            context.Options.Add(options);

            var language = new Language { ID = 1, Name = "English" };
            context.Languages.Add(language);
            language = new Language { ID = 2, Name = "German" };
            context.Languages.Add(language);
            language = new Language { ID = 3, Name = "Polish" };
            context.Languages.Add(language);

            var skill = new Skill { ID = 1, Name = "1st Test skill" };
            context.Skills.Add(skill);
            skill = new Skill { ID = 2, Name = "2st Test skill" };
            context.Skills.Add(skill);

            var school = new HighSchool { ID = 1, Name = "ChNU" };
            context.HighSchools.Add(school);
            school = new HighSchool { ID = 2, Name = "BSFEU" };
            context.HighSchools.Add(school);

            var candidate_l = new Candidate_Language { CandidateID = 1, LanguageID = 1, Level = "Upper-Intermediate" };
            context.Candidate_Language.Add(candidate_l);
            candidate_l = new Candidate_Language { CandidateID = 1, LanguageID = 3, Level = "Elementary" };
            context.Candidate_Language.Add(candidate_l);

            var candidate_sch = new Candidate_School { HighSchoolID = 1, CandidateID = 1, From = DateTime.Parse("2013-09-01"), To = DateTime.Parse("2018-05-01"), Degree = "Master" };
            context.Candidate_Schools.Add(candidate_sch);

            var candidate_sk = new Candidate_Skill { CandidateID = 1, SkillID = 1, Level = "Master", Month = 24 };
            context.Candidate_Skills.Add(candidate_sk);
            */
            context.SaveChanges();
        }
    }
}
