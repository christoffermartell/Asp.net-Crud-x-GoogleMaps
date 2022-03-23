﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_Exercise___Consid.Data;

#nullable disable

namespace Web_Exercise___Consid.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Web_Exercise___Consid.Models.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Notes")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("faa9e28f-ad20-498e-9da0-3e56da749c4d"),
                            Name = "Apple Company",
                            Notes = "Apple Inc. är ett amerikanskt dator - och hemelektronikföretag grundat 1976 av Steve Jobs, Steve Wozniak och Ronald Wayne. Företaget har cirka 147 000 anställda och omsatte 2020 nästan 274.52 miljarder amerikanska dollar.",
                            OrganizationNumber = 123321456
                        },
                        new
                        {
                            Id = new Guid("5989a286-ca8d-48a9-b1d5-d438a6862545"),
                            Name = "Ikea Company",
                            Notes = "Ikea Group, av företaget skrivet IKEA Group, är ett multinationellt möbelföretag, som grundades i Sverige år 1943 av Ingvar Kamprad som ett postorderföretag. Företaget ägs av en stiftelse i Nederländerna, men styrs alltjämt av familjen Kamprad.",
                            OrganizationNumber = 111111332
                        });
                });

            modelBuilder.Entity("Web_Exercise___Consid.Models.Entities.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Web_Exercise___Consid.Models.Entities.Store", b =>
                {
                    b.HasOne("Web_Exercise___Consid.Models.Entities.Company", "Companies")
                        .WithMany("Stores")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companies");
                });

            modelBuilder.Entity("Web_Exercise___Consid.Models.Entities.Company", b =>
                {
                    b.Navigation("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
