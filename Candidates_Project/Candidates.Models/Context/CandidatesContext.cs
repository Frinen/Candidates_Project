

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidates.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Web;
namespace Candidates.Models.Context
{
    public class CandidatesContext : DbContext
    {
        public CandidatesContext(DbContextOptions<CandidatesContext> options) : base(options)
        { }
        public DbSet<Candidate> Candidates { get; set; }
        //public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<CandidateLanguage> CandidateLanguages { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<HighSchool> HighSchools { get; set; }
        public DbSet<CandidateSchool> CandidateSchools { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Candidate>()
            .HasOne(p => p.Options)
            .WithOne(i => i.Candidate)
            .HasForeignKey<Options>(b => b.ID);

            modelBuilder.Entity<CandidateSkill>()
            .HasOne(pt => pt.Candidate)
            .WithMany(t => t.CandidateSkills)
            .HasForeignKey(pt => pt.CandidateID);

            modelBuilder.Entity<CandidateSkill>()
            .HasOne(pt => pt.Skill)
            .WithMany(t => t.CandidateSkills)
            .HasForeignKey(pt => pt.SkillID);

            modelBuilder.Entity<CandidateSchool>()
            .HasOne(pt => pt.Candidate)
            .WithMany(t => t.CandidateSchools)
            .HasForeignKey(pt => pt.CandidateID);

            modelBuilder.Entity<CandidateSchool>()
            .HasOne(pt => pt.HighSchool)
            .WithMany(t => t.CandidateSchool)
            .HasForeignKey(pt => pt.HighSchoolID);

            modelBuilder.Entity<CandidateLanguage>()
            .HasOne(pt => pt.Candidate)
            .WithMany(t => t.CandidateLanguages)
            .HasForeignKey(pt => pt.CandidateID);

            modelBuilder.Entity<CandidateLanguage>()
            .HasOne(pt => pt.Language)
            .WithMany(t => t.CandidateLanguages)
            .HasForeignKey(pt => pt.LanguageID);
            modelBuilder.Entity<Options>().HasKey(t => new {t.ID });
            modelBuilder.Entity<CandidateLanguage>().HasKey(t => new { t.CandidateID, t.LanguageID });
            modelBuilder.Entity<CandidateSchool>().HasKey(t => new { t.CandidateID, t.HighSchoolID });
            modelBuilder.Entity<CandidateSkill>().HasKey(t => new { t.CandidateID, t.SkillID });
        }
    }
    

    
}
