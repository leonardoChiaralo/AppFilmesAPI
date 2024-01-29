﻿// <auto-generated />
using System;
using AppFilmesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppFilmesAPI.Migrations.Artista;

[DbContext(typeof(AppFilmesContext))]
partial class ArtistaContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.1")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("AppFilmesAPI.Models.Artista", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<DateTime>("DataNascimento")
                    .HasColumnType("datetime2");

                b.Property<int>("Idade")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("int")
                    .HasComputedColumnSql("DATEDIFF(YEAR, DataNascimento, GETDATE())");

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Artistas");
            });
#pragma warning restore 612, 618
    }
}
