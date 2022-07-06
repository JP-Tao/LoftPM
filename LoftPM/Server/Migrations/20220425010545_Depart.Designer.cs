﻿// <auto-generated />
using System;
using LoftPM.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoftPM.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220425010545_Depart")]
    partial class Depart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LoftPM.Shared.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("LoftPM.Shared.Models.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamMemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TeamMemberId")
                        .IsUnique()
                        .HasFilter("[TeamMemberId] IS NOT NULL");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("LoftPM.Shared.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateInitialised")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateToBeComplete")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectManagerId")
                        .IsUnique()
                        .HasFilter("[ProjectManagerId] IS NOT NULL");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("LoftPM.Shared.Models.ProjectManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.ToTable("ProjectManagers");
                });

            modelBuilder.Entity("LoftPM.Shared.Models.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("ProjectTeamMember", b =>
                {
                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<int>("TeamMembersId")
                        .HasColumnType("int");

                    b.HasKey("ProjectsId", "TeamMembersId");

                    b.HasIndex("TeamMembersId");

                    b.ToTable("ProjectTeamMember");
                });

            modelBuilder.Entity("LoftPM.Shared.Models.Procedure", b =>
                {
                    b.HasOne("LoftPM.Shared.Models.Project", "Project")
                        .WithMany("Procedures")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoftPM.Shared.Models.TeamMember", "TeamMember")
                        .WithOne("Procedure")
                        .HasForeignKey("LoftPM.Shared.Models.Procedure", "TeamMemberId");

                    b.Navigation("Project");

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("LoftPM.Shared.Models.Project", b =>
                {
                    b.HasOne("LoftPM.Shared.Models.ProjectManager", "ProjectManager")
                        .WithOne("Project")
                        .HasForeignKey("LoftPM.Shared.Models.Project", "ProjectManagerId");

                    b.Navigation("ProjectManager");
                });

            modelBuilder.Entity("LoftPM.Shared.Models.ProjectManager", b =>
                {
                    b.HasOne("LoftPM.Shared.Models.Department", "Department")
                        .WithOne("ProjectManager")
                        .HasForeignKey("LoftPM.Shared.Models.ProjectManager", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("LoftPM.Shared.Models.TeamMember", b =>
                {
                    b.HasOne("LoftPM.Shared.Models.Department", "Department")
                        .WithOne("TeamMember")
                        .HasForeignKey("LoftPM.Shared.Models.TeamMember", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ProjectTeamMember", b =>
                {
                    b.HasOne("LoftPM.Shared.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoftPM.Shared.Models.TeamMember", null)
                        .WithMany()
                        .HasForeignKey("TeamMembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LoftPM.Shared.Models.Department", b =>
                {
                    b.Navigation("ProjectManager");

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("LoftPM.Shared.Models.Project", b =>
                {
                    b.Navigation("Procedures");
                });

            modelBuilder.Entity("LoftPM.Shared.Models.ProjectManager", b =>
                {
                    b.Navigation("Project")
                        .IsRequired();
                });

            modelBuilder.Entity("LoftPM.Shared.Models.TeamMember", b =>
                {
                    b.Navigation("Procedure");
                });
#pragma warning restore 612, 618
        }
    }
}
