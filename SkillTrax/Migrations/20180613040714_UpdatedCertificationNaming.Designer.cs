﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillTrax.Models;

namespace SkillTrax.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180613040714_UpdatedCertificationNaming")]
    partial class UpdatedCertificationNaming
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SkillTrax.Models.CertCategory", b =>
                {
                    b.Property<int>("CertCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CertCategoryName")
                        .IsRequired();

                    b.HasKey("CertCategoryId");

                    b.ToTable("CertificateCategory");
                });

            modelBuilder.Entity("SkillTrax.Models.Certification", b =>
                {
                    b.Property<int>("CertificationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CertCategoryId");

                    b.Property<string>("CertificationName")
                        .IsRequired();

                    b.HasKey("CertificationId");

                    b.HasIndex("CertCategoryId");

                    b.ToTable("Certificate");
                });

            modelBuilder.Entity("SkillTrax.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CertificationId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("RoleTypeId");

                    b.Property<int?>("SkillId");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CertificationId");

                    b.HasIndex("RoleTypeId");

                    b.HasIndex("SkillId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("SkillTrax.Models.EmployeeCert", b =>
                {
                    b.Property<int>("EmployeeCertId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CertificationId");

                    b.Property<int>("SkillId");

                    b.HasKey("EmployeeCertId");

                    b.HasIndex("CertificationId");

                    b.HasIndex("SkillId");

                    b.ToTable("EmployeeCert");
                });

            modelBuilder.Entity("SkillTrax.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeeSkillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<int>("SkillId");

                    b.HasKey("EmployeeSkillId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SkillId");

                    b.ToTable("EmployeeSkill");
                });

            modelBuilder.Entity("SkillTrax.Models.RoleType", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SkillTrax.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillName")
                        .IsRequired();

                    b.HasKey("SkillId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("SkillTrax.Models.SkillType", b =>
                {
                    b.Property<int>("SkillTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillTypeName")
                        .IsRequired();

                    b.HasKey("SkillTypeId");

                    b.ToTable("SkillType");
                });

            modelBuilder.Entity("SkillTrax.Models.SkillTypeSkill", b =>
                {
                    b.Property<int>("SkillTypeSkillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SkillId");

                    b.Property<int>("SkillTypeId");

                    b.HasKey("SkillTypeSkillId");

                    b.ToTable("SkillTypeSkill");
                });

            modelBuilder.Entity("SkillTrax.Models.Solution", b =>
                {
                    b.Property<int>("SolutionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SolutionName")
                        .IsRequired();

                    b.HasKey("SolutionId");

                    b.ToTable("Solution");
                });

            modelBuilder.Entity("SkillTrax.Models.SolutionSkill", b =>
                {
                    b.Property<int>("SolutionSkillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SkillId");

                    b.Property<int>("SolutionId");

                    b.HasKey("SolutionSkillId");

                    b.ToTable("SolutionSkill");
                });

            modelBuilder.Entity("SkillTrax.Models.Certification", b =>
                {
                    b.HasOne("SkillTrax.Models.CertCategory", "CertCategory")
                        .WithMany()
                        .HasForeignKey("CertCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkillTrax.Models.Employee", b =>
                {
                    b.HasOne("SkillTrax.Models.Certification")
                        .WithMany("Employees")
                        .HasForeignKey("CertificationId");

                    b.HasOne("SkillTrax.Models.RoleType", "RoleType")
                        .WithMany("Employees")
                        .HasForeignKey("RoleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkillTrax.Models.Skill")
                        .WithMany("Employees")
                        .HasForeignKey("SkillId");
                });

            modelBuilder.Entity("SkillTrax.Models.EmployeeCert", b =>
                {
                    b.HasOne("SkillTrax.Models.Certification", "Certification")
                        .WithMany()
                        .HasForeignKey("CertificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkillTrax.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkillTrax.Models.EmployeeSkill", b =>
                {
                    b.HasOne("SkillTrax.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkillTrax.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
