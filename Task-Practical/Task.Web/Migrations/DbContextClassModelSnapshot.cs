﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task.Web.Models.Dbcontext;

#nullable disable

namespace Task.Web.Migrations
{
    [DbContext(typeof(DbContextClass))]
    partial class DbContextClassModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task.Web.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Task.Web.Models.MeetingMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AttendsFromClientSide")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttendsFromHostSide")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("MeetingAgenda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeetingDecision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeetingDiscussion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeetingPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Meeting_Minutes_Master_Tbl", (string)null);
                });

            modelBuilder.Entity("Task.Web.Models.CorporateCustomer", b =>
                {
                    b.HasBaseType("Task.Web.Models.Customer");

                    b.ToTable("Corporate_Customer_Tbl", (string)null);
                });

            modelBuilder.Entity("Task.Web.Models.IndividualCustomer", b =>
                {
                    b.HasBaseType("Task.Web.Models.Customer");

                    b.ToTable("Individual_Customer_Tbl", (string)null);
                });

            modelBuilder.Entity("Task.Web.Models.MeetingMaster", b =>
                {
                    b.HasOne("Task.Web.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Task.Web.Models.CorporateCustomer", b =>
                {
                    b.HasOne("Task.Web.Models.Customer", null)
                        .WithOne()
                        .HasForeignKey("Task.Web.Models.CorporateCustomer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Task.Web.Models.IndividualCustomer", b =>
                {
                    b.HasOne("Task.Web.Models.Customer", null)
                        .WithOne()
                        .HasForeignKey("Task.Web.Models.IndividualCustomer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
