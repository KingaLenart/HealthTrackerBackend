﻿// <auto-generated />
using System;
using HealthTrackerApp.Core.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthTrackerApp.Core.SQL.Migrations
{
    [DbContext(typeof(HealthTrackerDatabaseContext))]
    [Migration("20231010210607_RemovePeriodTimeSpan")]
    partial class RemovePeriodTimeSpan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthTrackerApp.Core.Models.PeriodsCycle.PeriodCycleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsFirstPeriod")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PeriodFinishiDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PeriodStartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PeriodsCycle", (string)null);
                });

            modelBuilder.Entity("HealthTrackerApp.Core.Models.PhysicalActivities.PhysicalActivitieEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CaloriesBurned")
                        .HasColumnType("int");

                    b.Property<DateTime>("TrainingDay")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("TrainingLength")
                        .HasColumnType("time");

                    b.Property<int>("TypeOfPhysicalActivity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PhysicalActivitie", (string)null);
                });

            modelBuilder.Entity("HealthTrackerApp.Core.Models.Pregnancies.PregnancyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Conceiving")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsGirl")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pregnancies", (string)null);
                });

            modelBuilder.Entity("HealthTrackerApp.Core.Models.Users.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ForgotPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<float>("Heights")
                        .HasColumnType("real");

                    b.Property<bool>("IsPregnant")
                        .HasColumnType("bit");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshTokens")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NickName")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("HealthTrackerApp.Core.Models.PeriodsCycle.PeriodCycleEntity", b =>
                {
                    b.HasOne("HealthTrackerApp.Core.Models.Users.UserEntity", "User")
                        .WithMany("PeriodsCycle")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthTrackerApp.Core.Models.PhysicalActivities.PhysicalActivitieEntity", b =>
                {
                    b.HasOne("HealthTrackerApp.Core.Models.Users.UserEntity", "User")
                        .WithMany("PhysicalActivities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthTrackerApp.Core.Models.Pregnancies.PregnancyEntity", b =>
                {
                    b.HasOne("HealthTrackerApp.Core.Models.Users.UserEntity", "User")
                        .WithMany("Pregnancy")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthTrackerApp.Core.Models.Users.UserEntity", b =>
                {
                    b.Navigation("PeriodsCycle");

                    b.Navigation("PhysicalActivities");

                    b.Navigation("Pregnancy");
                });
#pragma warning restore 612, 618
        }
    }
}
