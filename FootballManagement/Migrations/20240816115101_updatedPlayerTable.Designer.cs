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
    [Migration("20240816115101_updatedPlayerTable")]
    partial class updatedPlayerTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
