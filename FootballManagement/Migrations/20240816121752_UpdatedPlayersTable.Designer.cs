﻿// <auto-generated />
using FootballManagement.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootballManagement.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240816121752_UpdatedPlayersTable")]
    partial class UpdatedPlayersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FootballManagement.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GoalsOfGuestTeam")
                        .HasColumnType("int");

                    b.Property<int>("GoalsOfHomeTeam")
                        .HasColumnType("int");

                    b.Property<int>("GuestTeamCode")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamCode")
                        .HasColumnType("int");

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("FootballManagement.Models.Team", b =>
                {
                    b.Property<int>("TeamCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamCode"));

                    b.Property<int>("NumberOfDefeat")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfEquality")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGoalsConceded")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGoalsScored")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfWins")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamCode");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.Property<int>("FormNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormNumber"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberOfGoalsScored")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("FormNumber");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.HasOne("FootballManagement.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FootballManagement.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
