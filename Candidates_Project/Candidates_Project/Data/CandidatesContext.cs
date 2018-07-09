using Candidates_Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Data
{
    public class CandidatesContext : DbContext
    {
        public CandidatesContext(DbContextOptions<CandidatesContext> options) : base(options)
        { }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Candidate_Language> CandidateLanguage { get; set; }
        public DbSet<HighSchool> HighSchools { get; set; }
        public DbSet<Candidate_School> Candidate_Schools { get; set; }
        public DbSet<Candidate_Skills> Candidate_Skills { get; set; }
        public DbSet<Skills> Skills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate_Language>().HasKey(t => new { t.CandidateID, t.LanguageID });
            modelBuilder.Entity<Candidate_School>().HasKey(t => new { t.CandidatesID, t.HighSchoolID });
            modelBuilder.Entity<Candidate_Skills>().HasKey(t => new { t.CandidateID, t.SkillsID });
        }
    }
    

    
}
