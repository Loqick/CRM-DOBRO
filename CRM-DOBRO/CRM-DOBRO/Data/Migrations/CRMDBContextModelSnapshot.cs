﻿// <auto-generated />
using System;
using CRM_DOBRO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRM_DOBRO.Migrations
{
    [DbContext(typeof(CRMDBContext))]
    partial class CRMDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CRM_DOBRO.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfLastChanges")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarketingId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarketingId");

                    b.ToTable("Contacts", (string)null);
                });

            modelBuilder.Entity("CRM_DOBRO.Entities.Lead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<int?>("SalerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("SalerId");

                    b.ToTable("Leads", (string)null);
                });

            modelBuilder.Entity("CRM_DOBRO.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfSale")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeadId")
                        .HasColumnType("int");

                    b.Property<int>("SalerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeadId");

                    b.HasIndex("SalerId");

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("CRM_DOBRO.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BlockingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("CRM_DOBRO.Entities.Contact", b =>
                {
                    b.HasOne("CRM_DOBRO.Entities.User", "Marketing")
                        .WithMany()
                        .HasForeignKey("MarketingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marketing");
                });

            modelBuilder.Entity("CRM_DOBRO.Entities.Lead", b =>
                {
                    b.HasOne("CRM_DOBRO.Entities.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM_DOBRO.Entities.User", "Saler")
                        .WithMany()
                        .HasForeignKey("SalerId");

                    b.Navigation("Contact");

                    b.Navigation("Saler");
                });

            modelBuilder.Entity("CRM_DOBRO.Entities.Sale", b =>
                {
                    b.HasOne("CRM_DOBRO.Entities.Lead", "Lead")
                        .WithMany()
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM_DOBRO.Entities.User", "Saler")
                        .WithMany()
                        .HasForeignKey("SalerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Lead");

                    b.Navigation("Saler");
                });
#pragma warning restore 612, 618
        }
    }
}