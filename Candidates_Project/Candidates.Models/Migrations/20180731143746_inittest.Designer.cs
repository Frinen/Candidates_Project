﻿// <auto-generated />
using System;
using Candidates.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Candidates.Models.Migrations
{
    [DbContext(typeof(CandidatesContext))]
    [Migration("20180731143746_inittest")]
    partial class inittest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Candidates.Models.Models.Account", b =>
                {
                    b.Property<string>("Login")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Role")
                        .IsRequired();

                    b.HasKey("Login");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Candidates.Models.Models.Candidate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("Sex")
                        .IsRequired();

                    b.Property<string>("Skype");

                    b.HasKey("ID");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Candidates.Models.Models.CandidateLanguage", b =>
                {
                    b.Property<int>("CandidateID");

                    b.Property<int>("LanguageID");

                    b.Property<string>("Level")
                        .IsRequired();

                    b.HasKey("CandidateID", "LanguageID");

                    b.HasIndex("LanguageID");

                    b.ToTable("CandidateLanguages");
                });

            modelBuilder.Entity("Candidates.Models.Models.CandidateSchool", b =>
                {
                    b.Property<int>("CandidateID");

                    b.Property<int>("HighSchoolID");

                    b.Property<string>("Degree")
                        .IsRequired();

                    b.Property<DateTime>("From");

                    b.Property<DateTime>("To");

                    b.HasKey("CandidateID", "HighSchoolID");

                    b.HasIndex("HighSchoolID");

                    b.ToTable("CandidateSchools");
                });

            modelBuilder.Entity("Candidates.Models.Models.CandidateSkill", b =>
                {
                    b.Property<int>("CandidateID");

                    b.Property<int>("SkillID");

                    b.Property<string>("Level")
                        .IsRequired();

                    b.Property<int>("Month");

                    b.HasKey("CandidateID", "SkillID");

                    b.HasIndex("SkillID");

                    b.ToTable("CandidateSkills");
                });

            modelBuilder.Entity("Candidates.Models.Models.HighSchool", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("HighSchools");
                });

            modelBuilder.Entity("Candidates.Models.Models.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Candidates.Models.Models.Options", b =>
                {
                    b.Property<int>("ID");

                    b.Property<bool>("CanRelocate");

                    b.Property<bool>("CanWorkInTheOffice");

                    b.Property<bool>("CanWorkRemotly");

                    b.HasKey("ID");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Candidates.Models.Models.Skill", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Candidates.Models.Models.CandidateLanguage", b =>
                {
                    b.HasOne("Candidates.Models.Models.Candidate", "Candidate")
                        .WithMany("CandidateLanguages")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Candidates.Models.Models.Language", "Language")
                        .WithMany("CandidateLanguages")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Candidates.Models.Models.CandidateSchool", b =>
                {
                    b.HasOne("Candidates.Models.Models.Candidate", "Candidate")
                        .WithMany("CandidateSchools")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Candidates.Models.Models.HighSchool", "HighSchool")
                        .WithMany("CandidateSchool")
                        .HasForeignKey("HighSchoolID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Candidates.Models.Models.CandidateSkill", b =>
                {
                    b.HasOne("Candidates.Models.Models.Candidate", "Candidate")
                        .WithMany("CandidateSkills")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Candidates.Models.Models.Skill", "Skill")
                        .WithMany("CandidateSkills")
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Candidates.Models.Models.Options", b =>
                {
                    b.HasOne("Candidates.Models.Models.Candidate", "Candidate")
                        .WithOne("Options")
                        .HasForeignKey("Candidates.Models.Models.Options", "ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
