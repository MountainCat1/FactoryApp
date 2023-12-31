﻿// <auto-generated />
using System;
using FactoryApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FactoryApp.Migrations
{
    [DbContext(typeof(FactoryDbContext))]
    partial class FactoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("FactoryApp.Models.DirectorModel", b =>
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

            modelBuilder.Entity("FactoryApp.Models.RepairmenModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Repairmen");
                });

            modelBuilder.Entity("FactoryApp.Models.WorkshopModel", b =>
                {
                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("TEXT");

                    b.HasKey("Region");

                    b.HasIndex("DirectorId");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("FactoryApp.Models.WorkshopModel", b =>
                {
                    b.HasOne("FactoryApp.Models.DirectorModel", "DirectorModel")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DirectorModel");
                });
#pragma warning restore 612, 618
        }
    }
}
