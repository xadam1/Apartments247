﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApartmentsDbContext))]
    partial class ApartmentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("DAL.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("State")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("Zip")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DAL.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Best"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Black"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Green"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Red"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Orange"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Yellow"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Brown"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Purple"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Violet"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Pink"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Salmon"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Khaki"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Blue"
                        });
                });

            modelBuilder.Entity("DAL.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Content")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("DAL.Models.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CostType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("DAL.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Equipments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Lednička"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Pračka"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Sušička"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Plynová maska"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Pouta, bičíky a LaTeXový obleček"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Žehlicí prkno"
                        },
                        new
                        {
                            Id = 7,
                            Type = "Topinkovač"
                        },
                        new
                        {
                            Id = 8,
                            Type = "Mikrovlnka"
                        },
                        new
                        {
                            Id = 9,
                            Type = "Kolíčky na prádlo"
                        },
                        new
                        {
                            Id = 10,
                            Type = "Ptačí budka"
                        });
                });

            modelBuilder.Entity("DAL.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTimeUploaded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("Path")
                        .HasColumnType("TEXT")
                        .HasMaxLength(512);

                    b.Property<int>("UnitId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("DAL.Models.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Note")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("ColorId");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("DAL.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContractId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MaxCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MonthlyIncome")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecificationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("SpecificationId");

                    b.HasIndex("UnitGroupId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("DAL.Models.UnitEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("UnitId");

                    b.ToTable("UnitEquipment");
                });

            modelBuilder.Entity("DAL.Models.UnitGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecificationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SpecificationId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("UnitGroups");
                });

            modelBuilder.Entity("DAL.Models.UnitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("UnitTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Byt"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Řadový dům"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Dům se zahradou"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Garáž"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Školní třída"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Rodinná hrobka"
                        },
                        new
                        {
                            Id = 7,
                            Type = "Parkovací místo"
                        },
                        new
                        {
                            Id = 8,
                            Type = "Autobusová zastávka"
                        });
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Models.Cost", b =>
                {
                    b.HasOne("DAL.Models.Unit", "Unit")
                        .WithMany("Costs")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.Photo", b =>
                {
                    b.HasOne("DAL.Models.Unit", "Unit")
                        .WithMany("Photos")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.Specification", b =>
                {
                    b.HasOne("DAL.Models.Address", "Address")
                        .WithOne()
                        .HasForeignKey("DAL.Models.Specification", "AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.Unit", b =>
                {
                    b.HasOne("DAL.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Models.Specification", "Specification")
                        .WithMany()
                        .HasForeignKey("SpecificationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Models.UnitGroup", "UnitGroup")
                        .WithMany("Units")
                        .HasForeignKey("UnitGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Models.UnitType", "UnitType")
                        .WithMany("Units")
                        .HasForeignKey("UnitTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.UnitEquipment", b =>
                {
                    b.HasOne("DAL.Models.Equipment", "Equipment")
                        .WithMany("UnitEquipments")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Models.Unit", "Unit")
                        .WithMany("UnitEquipments")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.UnitGroup", b =>
                {
                    b.HasOne("DAL.Models.Specification", "Specification")
                        .WithOne()
                        .HasForeignKey("DAL.Models.UnitGroup", "SpecificationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("UnitGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
