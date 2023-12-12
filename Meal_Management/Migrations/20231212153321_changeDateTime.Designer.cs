﻿// <auto-generated />
using System;
using Meal_Management.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Meal_Management.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231212153321_changeDateTime")]
    partial class changeDateTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Meal_Management.Models.Market", b =>
                {
                    b.Property<int>("marketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("marketId"));

                    b.Property<DateOnly>("marketDate")
                        .HasColumnType("date");

                    b.Property<double>("totalDailyMarket")
                        .HasColumnType("float");

                    b.Property<double>("totalDailyMeal")
                        .HasColumnType("float");

                    b.HasKey("marketId");

                    b.ToTable("markets");
                });

            modelBuilder.Entity("Meal_Management.Models.MealManagement", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<DateOnly>("dateDate")
                        .HasColumnType("date");

                    b.Property<double>("deposit")
                        .HasColumnType("float");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("meal")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("mealManagements");
                });
#pragma warning restore 612, 618
        }
    }
}