﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ozowebapp.Models;

namespace ozowebapp.Migrations
{
    [DbContext(typeof(ConnectionStringClass))]
    [Migration("20200602124848_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ozowebapp.Models.CheckBoxViewModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Checked")
                        .HasColumnType("bit");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UslugaViewModelUslugaClassID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UslugaViewModelUslugaClassID");

                    b.ToTable("CheckBoxViewModel");
                });

            modelBuilder.Entity("ozowebapp.Models.CheckBoxViewModelOprema", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Checked")
                        .HasColumnType("bit");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UslugaViewModelUslugaClassID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UslugaViewModelUslugaClassID");

                    b.ToTable("CheckBoxViewModelOprema");
                });

            modelBuilder.Entity("ozowebapp.Models.DjelatnikClass", b =>
                {
                    b.Property<int>("DjelatnikClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Datum_rodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZanimanjeClassID")
                        .HasColumnType("int");

                    b.HasKey("DjelatnikClassID");

                    b.HasIndex("ZanimanjeClassID");

                    b.ToTable("Djelatnik");
                });

            modelBuilder.Entity("ozowebapp.Models.OpremaClass", b =>
                {
                    b.Property<int>("OpremaClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Cijena")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<DateTime?>("Datum_proizvodnje")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Duljina_Koristenja_u_h")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int?>("Kolicina")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Lokacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OpremaClassID");

                    b.ToTable("Oprema");
                });

            modelBuilder.Entity("ozowebapp.Models.UslugaClass", b =>
                {
                    b.Property<int>("UslugaClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<string>("Lokacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UslugaClassID");

                    b.ToTable("UslugaClass");
                });

            modelBuilder.Entity("ozowebapp.Models.UslugaToOprema", b =>
                {
                    b.Property<int>("UslugaToOpremaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OpremaClassID")
                        .HasColumnType("int");

                    b.Property<int>("UslugaClassID")
                        .HasColumnType("int");

                    b.HasKey("UslugaToOpremaID");

                    b.HasIndex("OpremaClassID");

                    b.HasIndex("UslugaClassID");

                    b.ToTable("UslugaToOpremas");
                });

            modelBuilder.Entity("ozowebapp.Models.UslugaToZanimanje", b =>
                {
                    b.Property<int>("UslugaToZanimanjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UslugaClassID")
                        .HasColumnType("int");

                    b.Property<int>("ZanimanjeClassID")
                        .HasColumnType("int");

                    b.HasKey("UslugaToZanimanjeID");

                    b.HasIndex("UslugaClassID");

                    b.HasIndex("ZanimanjeClassID");

                    b.ToTable("UslugaToZanimanjes");
                });

            modelBuilder.Entity("ozowebapp.Models.UslugaViewModel", b =>
                {
                    b.Property<int>("UslugaClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<string>("Lokacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UslugaClassID");

                    b.ToTable("UslugaViewModel");
                });

            modelBuilder.Entity("ozowebapp.Models.ZanimanjeClass", b =>
                {
                    b.Property<int>("ZanimanjeClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Satnica")
                        .IsRequired()
                        .HasColumnType("float");

                    b.HasKey("ZanimanjeClassID");

                    b.ToTable("Zanimanje");
                });

            modelBuilder.Entity("ozowebapp.Models.CheckBoxViewModel", b =>
                {
                    b.HasOne("ozowebapp.Models.UslugaViewModel", null)
                        .WithMany("Zanimanja")
                        .HasForeignKey("UslugaViewModelUslugaClassID");
                });

            modelBuilder.Entity("ozowebapp.Models.CheckBoxViewModelOprema", b =>
                {
                    b.HasOne("ozowebapp.Models.UslugaViewModel", null)
                        .WithMany("Oprema")
                        .HasForeignKey("UslugaViewModelUslugaClassID");
                });

            modelBuilder.Entity("ozowebapp.Models.DjelatnikClass", b =>
                {
                    b.HasOne("ozowebapp.Models.ZanimanjeClass", "ZanimanjeClass")
                        .WithMany("Djelatnici")
                        .HasForeignKey("ZanimanjeClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ozowebapp.Models.UslugaToOprema", b =>
                {
                    b.HasOne("ozowebapp.Models.OpremaClass", "OpremaClass")
                        .WithMany("UslugaToOpremas")
                        .HasForeignKey("OpremaClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ozowebapp.Models.UslugaClass", "UslugaClass")
                        .WithMany("UslugaToOpremas")
                        .HasForeignKey("UslugaClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ozowebapp.Models.UslugaToZanimanje", b =>
                {
                    b.HasOne("ozowebapp.Models.UslugaClass", "UslugaClass")
                        .WithMany("UslugaToZanimanjes")
                        .HasForeignKey("UslugaClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ozowebapp.Models.ZanimanjeClass", "ZanimanjeClass")
                        .WithMany("UslugaToZanimanjes")
                        .HasForeignKey("ZanimanjeClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
