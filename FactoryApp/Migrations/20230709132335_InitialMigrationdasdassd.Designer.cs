﻿// <auto-generated />
using System;
using FactoryApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FactoryApp.Migrations
{
    [DbContext(typeof(FactoryDbContext))]
    [Migration("20230709132335_InitialMigrationdasdassd")]
    partial class InitialMigrationdasdassd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("FactoryApp.Models.Director", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("FactoryApp.Models.Workshop", b =>
                {
                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("TEXT");

                    b.HasKey("Region");

                    b.HasIndex("DirectorId");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("FactoryApp.Models.Workshop", b =>
                {
                    b.HasOne("FactoryApp.Models.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });
#pragma warning restore 612, 618
        }
    }
}
