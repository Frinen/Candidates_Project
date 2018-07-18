using Candidates.Models.Context;
using Candidates.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Services
{
    public class CandidateSchoolService
    {
        static public void Create(CandidatesContext context, int highSchoolID, int candidateID, string from, string to, string degree)
        {
            context.Database.EnsureCreated();
            var candidateschool = new CandidateSchool {HighSchoolID = highSchoolID, CandidateID = candidateID, From = DateTime.Parse(from), To = DateTime.Parse(to), Degree = degree };
            context.CandidateSchools.Add(candidateschool);
            context.SaveChanges();
        }
        public static void Update(CandidatesContext context, int id, CandidateSchool candidateSchool)
        {



        }
        public static void Remove(CandidatesContext context, int highSchoolID, int candidateID)
        {
            var candidateSchool = context.CandidateSchools.Find(highSchoolID, candidateID);
            if (candidateSchool != null)
            {
                context.CandidateSchools.Remove(candidateSchool);
                context.SaveChanges();
            }
        }
        public static CandidateSchool Display(CandidatesContext context, int highSchoolID, int candidateID)
        {
            var candidateSchool = context.CandidateSchools.Find(highSchoolID, candidateID);
            if (candidateSchool != null)
                return candidateSchool;
            else
                return null;
        }
    }
}
