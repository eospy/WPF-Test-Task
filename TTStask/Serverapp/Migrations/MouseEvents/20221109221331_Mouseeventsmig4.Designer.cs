﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Serverapp;

#nullable disable

namespace Serverapp.Migrations.MouseEvents
{
    [DbContext(typeof(MouseEventsContext))]
    [Migration("20221109221331_Mouseeventsmig4")]
    partial class Mouseeventsmig4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Serverapp.Mouseevents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("XCoord")
                        .HasColumnType("REAL");

                    b.Property<double>("YCoord")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Mouseevents");
                });
#pragma warning restore 612, 618
        }
    }
}
