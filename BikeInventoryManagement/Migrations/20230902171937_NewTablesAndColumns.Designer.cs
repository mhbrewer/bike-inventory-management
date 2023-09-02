﻿// <auto-generated />
using System;
using BikeInventoryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BikeInventoryManagement.Migrations
{
    [DbContext(typeof(BikeInventoryManagementContext))]
    [Migration("20230902171937_NewTablesAndColumns")]
    partial class NewTablesAndColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BikeInventoryManagement.Models.Bike", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BikeTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Cost")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("FrameSizeCm")
                        .HasColumnType("int");

                    b.Property<bool>("InventoryCount")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBoxed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsListable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double?>("ListPrice")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StorageLocationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BikeTypeID");

                    b.HasIndex("StorageLocationID");

                    b.ToTable("Bike");
                });

            modelBuilder.Entity("BikeInventoryManagement.Models.BikeType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("BikeType");
                });

            modelBuilder.Entity("BikeInventoryManagement.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SqFtSize")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("BikeInventoryManagement.Models.Bike", b =>
                {
                    b.HasOne("BikeInventoryManagement.Models.BikeType", "BikeType")
                        .WithMany()
                        .HasForeignKey("BikeTypeID");

                    b.HasOne("BikeInventoryManagement.Models.Location", "StorageLocation")
                        .WithMany()
                        .HasForeignKey("StorageLocationID");

                    b.Navigation("BikeType");

                    b.Navigation("StorageLocation");
                });
#pragma warning restore 612, 618
        }
    }
}
