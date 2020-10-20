﻿// <auto-generated />
using System;
using ApartmentsDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApartmentsDAL.Migrations
{
    [DbContext(typeof(ApartmentsDbContext))]
    partial class ApartmentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApartmentsDAL.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ApartmentsDAL.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("ApartmentsDAL.Models.EquipmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("EquipmentTypes");
                });

            modelBuilder.Entity("ApartmentsDAL.Models.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("ApartmentsDAL.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentCapacity")
                        .HasColumnType("int");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<int>("SpecificationId")
                        .HasColumnType("int");

                    b.Property<int?>("UnitGroupId")
                        .HasColumnType("int");

                    b.Property<int>("UnitTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecificationId");

                    b.HasIndex("UnitGroupId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("ApartmentsDAL.Models.UnitGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SpecificationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecificationId");

                    b.ToTable("UnitGroups");
                });

            modelBuilder.Entity("ApartmentsDAL.Models.UnitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("UnitTypes");
                });

            modelBuilder.Entity("ApartmentsDAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApartmentsDAL.Models.Equipment", b =>
                {
                    b.HasOne("ApartmentsDAL.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApartmentsDAL.Models.EquipmentType", b =>
                {
                    b.HasOne("ApartmentsDAL.Models.Equipment", null)
                        .WithMany("AvailableEquipment")
                        .HasForeignKey("EquipmentId");
                });

            modelBuilder.Entity("ApartmentsDAL.Models.Specification", b =>
                {
                    b.HasOne("ApartmentsDAL.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApartmentsDAL.Models.Unit", b =>
                {
                    b.HasOne("ApartmentsDAL.Models.Specification", "Specification")
                        .WithMany()
                        .HasForeignKey("SpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApartmentsDAL.Models.UnitGroup", null)
                        .WithMany("Units")
                        .HasForeignKey("UnitGroupId");

                    b.HasOne("ApartmentsDAL.Models.UnitType", "Type")
                        .WithMany()
                        .HasForeignKey("UnitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApartmentsDAL.Models.UnitGroup", b =>
                {
                    b.HasOne("ApartmentsDAL.Models.Specification", "Specification")
                        .WithMany()
                        .HasForeignKey("SpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
