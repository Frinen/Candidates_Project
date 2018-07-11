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
        public DbSet<Candidate_Language> Candidate_Language { get; set; }
        public DbSet<Language> Languages { get; set; }
        
        public DbSet<HighSchool> HighSchools { get; set; }
        public DbSet<Candidate_School> Candidate_Schools { get; set; }
        public DbSet<Candidate_Skill> Candidate_Skills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Candidate>()
            .HasOne(p => p.Options)
            .WithOne(i => i.Candidate)
            .HasForeignKey<Options>(b => b.CandidateID);

            modelBuilder.Entity<Candidate_Skill>()
            .HasOne(pt => pt.Candidate)
            .WithMany(t => t.Candidate_Skills)
            .HasForeignKey(pt => pt.CandidateID);

            modelBuilder.Entity<Candidate_Skill>()
            .HasOne(pt => pt.Skills)
            .WithMany(t => t.Candidate_Skills)
            .HasForeignKey(pt => pt.SkillID);

            modelBuilder.Entity<Candidate_School>()
            .HasOne(pt => pt.Candidate)
            .WithMany(t => t.Candidate_School)
            .HasForeignKey(pt => pt.CandidateID);

            modelBuilder.Entity<Candidate_School>()
            .HasOne(pt => pt.HighSchool)
            .WithMany(t => t.Candidate_School)
            .HasForeignKey(pt => pt.HighSchoolID);

            modelBuilder.Entity<Candidate_Language>()
            .HasOne(pt => pt.Candidate)
            .WithMany(t => t.Candidate_Language)
            .HasForeignKey(pt => pt.CandidateID);

            modelBuilder.Entity<Candidate_Language>()
            .HasOne(pt => pt.Language)
            .WithMany(t => t.Candidate_Language)
            .HasForeignKey(pt => pt.LanguageID);

            modelBuilder.Entity<Candidate_Language>().HasKey(t => new { t.CandidateID, t.LanguageID });
            modelBuilder.Entity<Candidate_School>().HasKey(t => new { t.CandidateID, t.HighSchoolID });
            modelBuilder.Entity<Candidate_Skill>().HasKey(t => new { t.CandidateID, t.SkillID });
        }
    }
    

    
}
