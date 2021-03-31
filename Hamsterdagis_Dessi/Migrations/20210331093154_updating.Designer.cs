﻿// <auto-generated />
using System;
using Hamsterdagis_Dessi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hamsterdagis_Dessi.Migrations
{
    [DbContext(typeof(HamsterAppContext))]
    [Migration("20210331093154_updating")]
    partial class updating
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd_database.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("BackEnd_database.Cage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cage_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cages");
                });

            modelBuilder.Entity("BackEnd_database.Cage_Buddies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountOfBuddies")
                        .HasColumnType("int");

                    b.Property<int?>("CageId")
                        .HasColumnType("int");

                    b.Property<int?>("GenderInCageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.HasIndex("GenderInCageId");

                    b.ToTable("Cage_Buddies");
                });

            modelBuilder.Entity("BackEnd_database.ExerciseArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountInArea")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ExerciseAreas");
                });

            modelBuilder.Entity("BackEnd_database.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("BackEnd_database.Hamster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("Cage_BuddiesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CheckInTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExerciseAreaId")
                        .HasColumnType("int");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Hamster_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeForLastExercise")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("Cage_BuddiesId");

                    b.HasIndex("ExerciseAreaId");

                    b.HasIndex("GenderId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Hamsters");
                });

            modelBuilder.Entity("BackEnd_database.Logg_Activities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int?>("HamsterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("HamsterId");

                    b.ToTable("Logg_Activities");
                });

            modelBuilder.Entity("BackEnd_database.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("BackEnd_database.Cage_Buddies", b =>
                {
                    b.HasOne("BackEnd_database.Cage", "Cage")
                        .WithMany()
                        .HasForeignKey("CageId");

                    b.HasOne("BackEnd_database.Gender", "GenderInCage")
                        .WithMany()
                        .HasForeignKey("GenderInCageId");

                    b.Navigation("Cage");

                    b.Navigation("GenderInCage");
                });

            modelBuilder.Entity("BackEnd_database.Hamster", b =>
                {
                    b.HasOne("BackEnd_database.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("BackEnd_database.Cage_Buddies", null)
                        .WithMany("Hamsters")
                        .HasForeignKey("Cage_BuddiesId");

                    b.HasOne("BackEnd_database.ExerciseArea", null)
                        .WithMany("Hamsters")
                        .HasForeignKey("ExerciseAreaId");

                    b.HasOne("BackEnd_database.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("BackEnd_database.Owner", "Owner")
                        .WithMany("Hamsters")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Activity");

                    b.Navigation("Gender");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BackEnd_database.Logg_Activities", b =>
                {
                    b.HasOne("BackEnd_database.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("BackEnd_database.Hamster", "Hamster")
                        .WithMany()
                        .HasForeignKey("HamsterId");

                    b.Navigation("Activity");

                    b.Navigation("Hamster");
                });

            modelBuilder.Entity("BackEnd_database.Cage_Buddies", b =>
                {
                    b.Navigation("Hamsters");
                });

            modelBuilder.Entity("BackEnd_database.ExerciseArea", b =>
                {
                    b.Navigation("Hamsters");
                });

            modelBuilder.Entity("BackEnd_database.Owner", b =>
                {
                    b.Navigation("Hamsters");
                });
#pragma warning restore 612, 618
        }
    }
}
