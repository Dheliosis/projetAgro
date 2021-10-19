﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nomenclatures.Data;

namespace Nomenclatures.Migrations
{
    [DbContext(typeof(NomenclaturesContext))]
    partial class NomenclaturesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nomenclatures.Data.ComponentQty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComposeId")
                        .HasColumnType("int");

                    b.Property<int?>("MPId")
                        .HasColumnType("int");

                    b.Property<int?>("PSFId")
                        .HasColumnType("int");

                    b.Property<double>("Qty")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ComposeId");

                    b.HasIndex("MPId");

                    b.HasIndex("PSFId");

                    b.ToTable("Composants");
                });

            modelBuilder.Entity("Nomenclatures.Data.FamilleMatierePremiere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan?>("DureeOptimaleUtilisation")
                        .HasColumnType("time");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FamillesPremieres");
                });

            modelBuilder.Entity("Nomenclatures.Data.MatierePremiere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bio")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("DureeConservation")
                        .HasColumnType("time");

                    b.Property<int?>("FamilleId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PoidsUnitaire")
                        .HasColumnType("float");

                    b.Property<int>("PourcentageHumidite")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FamilleId");

                    b.ToTable("MatieresPremieres");
                });

            modelBuilder.Entity("Nomenclatures.Data.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bio")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Produits");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Produit");
                });

            modelBuilder.Entity("Nomenclatures.Data.ProduitFini", b =>
                {
                    b.HasBaseType("Nomenclatures.Data.Produit");

                    b.HasDiscriminator().HasValue("ProduitFini");
                });

            modelBuilder.Entity("Nomenclatures.Data.ProduitSemiFini", b =>
                {
                    b.HasBaseType("Nomenclatures.Data.Produit");

                    b.HasDiscriminator().HasValue("ProduitSemiFini");
                });

            modelBuilder.Entity("Nomenclatures.Data.ComponentQty", b =>
                {
                    b.HasOne("Nomenclatures.Data.Produit", "Compose")
                        .WithMany("Composants")
                        .HasForeignKey("ComposeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Nomenclatures.Data.MatierePremiere", "MP")
                        .WithMany()
                        .HasForeignKey("MPId");

                    b.HasOne("Nomenclatures.Data.ProduitSemiFini", "PSF")
                        .WithMany()
                        .HasForeignKey("PSFId");

                    b.Navigation("Compose");

                    b.Navigation("MP");

                    b.Navigation("PSF");
                });

            modelBuilder.Entity("Nomenclatures.Data.MatierePremiere", b =>
                {
                    b.HasOne("Nomenclatures.Data.FamilleMatierePremiere", "Famille")
                        .WithMany()
                        .HasForeignKey("FamilleId");

                    b.Navigation("Famille");
                });

            modelBuilder.Entity("Nomenclatures.Data.Produit", b =>
                {
                    b.Navigation("Composants");
                });
#pragma warning restore 612, 618
        }
    }
}
