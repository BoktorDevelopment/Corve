﻿// <auto-generated />
using CorveTool.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CorveTool.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20170915104903_InitialCreate14")]
    partial class InitialCreate14
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CorveTool.DAL.Models.Schedules", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("When");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("CorveTool.DAL.Models.ScheduleTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SchedulesId");

                    b.Property<int>("TaskID");

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("SchedulesId");

                    b.ToTable("ScheduleTask");
                });

            modelBuilder.Entity("CorveTool.DAL.Models.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Task");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("CorveTool.DAL.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Email");

                    b.Property<int>("Name");

                    b.Property<int>("SlackName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CorveTool.DAL.Models.ScheduleTask", b =>
                {
                    b.HasOne("CorveTool.DAL.Models.Schedules")
                        .WithMany("ScheduleTask")
                        .HasForeignKey("SchedulesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}