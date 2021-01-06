﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DAL.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("State")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Zip")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Brno",
                            Number = "679/6",
                            State = "Česká Republika",
                            Street = "Leitnerova",
                            Zip = "602 00"
                        },
                        new
                        {
                            Id = 2,
                            City = "Bratislava",
                            Number = "4",
                            State = "Slovensko",
                            Street = "Hnojová",
                            Zip = "00 11 22"
                        },
                        new
                        {
                            Id = 3,
                            City = "Varšava",
                            Number = "13",
                            State = "Polsko",
                            Street = "U Lesa",
                            Zip = "314 52"
                        },
                        new
                        {
                            Id = 4,
                            City = "Budapešť",
                            Number = "8",
                            State = "Maďarsko",
                            Street = "Křovácká",
                            Zip = "451 732"
                        },
                        new
                        {
                            Id = 5,
                            City = "Berlín",
                            Number = "151",
                            State = "Německo",
                            Street = "Bedřicha Šubčíka",
                            Zip = "38 729"
                        },
                        new
                        {
                            Id = 6,
                            City = "Bělehrad",
                            Number = "3",
                            State = "Jugoslávie",
                            Street = "Zámečnická",
                            Zip = "44 55"
                        },
                        new
                        {
                            Id = 7,
                            City = "Vídeň",
                            Number = "3",
                            State = "Rakousko",
                            Street = "Václavská",
                            Zip = "44 55"
                        },
                        new
                        {
                            Id = 8,
                            City = "Lublaň",
                            Number = "3",
                            State = "Slovinsko",
                            Street = "Mečová",
                            Zip = "44 55"
                        },
                        new
                        {
                            Id = 9,
                            City = "Madrid",
                            Number = "3",
                            State = "Španělsko",
                            Street = "Kozí",
                            Zip = "44 55"
                        },
                        new
                        {
                            Id = 10,
                            City = "Lisabon",
                            Number = "3",
                            State = "Portugalsko",
                            Street = "Kobližná",
                            Zip = "44 55"
                        },
                        new
                        {
                            Id = 11,
                            City = "Řím",
                            Number = "3",
                            State = "Itálie",
                            Street = "Dominikánská",
                            Zip = "44 55"
                        },
                        new
                        {
                            Id = 12,
                            City = "Amsterdam",
                            Number = "3",
                            State = "Nizozemsko",
                            Street = "Botanická",
                            Zip = "44 55"
                        },
                        new
                        {
                            Id = 13,
                            City = "Paříž",
                            Number = "3",
                            State = "Francie",
                            Street = "Hybešova",
                            Zip = "44 55"
                        });
                });

            modelBuilder.Entity("DAL.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("DAL.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Type")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Equipment");

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
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateTimeUploaded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Path")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int?>("UnitId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.HasIndex("UnitId1");

                    b.ToTable("Photo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateTimeUploaded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Krásná fotografie obýváku",
                            Name = "Obývák",
                            Path = "/",
                            UnitId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateTimeUploaded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Janči odnášející mrtvolu do sklepa",
                            Name = "Schody do sklepa",
                            Path = "/",
                            UnitId = 2
                        },
                        new
                        {
                            Id = 3,
                            DateTimeUploaded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Aparatura k vaření perníku",
                            Name = "Kuchyně",
                            Path = "/",
                            UnitId = 3
                        },
                        new
                        {
                            Id = 4,
                            DateTimeUploaded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Výhled z okna",
                            Name = "Okno",
                            Path = "/",
                            UnitId = 4
                        },
                        new
                        {
                            Id = 5,
                            DateTimeUploaded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Dětské hřiště před domem",
                            Name = "Hřiště",
                            Path = "/",
                            UnitId = 5
                        },
                        new
                        {
                            Id = 6,
                            DateTimeUploaded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Zde se trápí hladem zlobivé děti",
                            Name = "Hladomorna",
                            Path = "/",
                            UnitId = 6
                        },
                        new
                        {
                            Id = 7,
                            DateTimeUploaded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Pokoj s postelí a nočním stolkem",
                            Name = "Hotelový pokoj",
                            Path = "/",
                            UnitId = 7
                        },
                        new
                        {
                            Id = 8,
                            DateTimeUploaded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Výhled na široké okolí",
                            Name = "Rozhledna",
                            Path = "/",
                            UnitId = 8
                        },
                        new
                        {
                            Id = 9,
                            DateTimeUploaded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Kovář kovající podkovu",
                            Name = "Kovárna",
                            Path = "/",
                            UnitId = 9
                        });
                });

            modelBuilder.Entity("DAL.Models.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Note")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("ColorId");

                    b.ToTable("Specifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            ColorId = 13,
                            Name = "Leitnerka",
                            Note = "Obyčejný byt"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            ColorId = 12,
                            Name = "Prostřední byt",
                            Note = "4. patro"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            ColorId = 11,
                            Name = "Byt 13",
                            Note = "Sousedi"
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 4,
                            ColorId = 10,
                            Name = "D1",
                            Note = "Mučírna"
                        },
                        new
                        {
                            Id = 5,
                            AddressId = 5,
                            ColorId = 9,
                            Name = "B311",
                            Note = "Počítačová učebna"
                        },
                        new
                        {
                            Id = 6,
                            AddressId = 6,
                            ColorId = 8,
                            Name = "Hliněného kabinet",
                            Note = "Hliňasovo království"
                        },
                        new
                        {
                            Id = 7,
                            AddressId = 7,
                            ColorId = 7,
                            Name = "Tomčiho chata",
                            Note = "Tady bylo vyhuleno mnoho trávy"
                        },
                        new
                        {
                            Id = 8,
                            AddressId = 8,
                            ColorId = 6,
                            Name = "Tomčiho dětský pokoj",
                            Note = "Je v něm spousta plyšáků"
                        },
                        new
                        {
                            Id = 9,
                            AddressId = 9,
                            ColorId = 5,
                            Name = "Jančiho dům",
                            Note = "Rodinný dům s bazénem"
                        },
                        new
                        {
                            Id = 10,
                            AddressId = 10,
                            ColorId = 4,
                            Name = "Tomčiho majetek",
                            Note = "Tady je Krakonošovo"
                        },
                        new
                        {
                            Id = 11,
                            AddressId = 11,
                            ColorId = 3,
                            Name = "Fakulta Informatiky",
                            Note = "Všemi nenáviděná budova"
                        },
                        new
                        {
                            Id = 12,
                            AddressId = 12,
                            ColorId = 2,
                            Name = "Jančiho domeček",
                            Note = "A tady žije El Jančitas"
                        },
                        new
                        {
                            Id = 13,
                            AddressId = 13,
                            ColorId = 1,
                            Name = "Vojtův domeček",
                            Note = "Tohle všechno mi patří"
                        });
                });

            modelBuilder.Entity("DAL.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ContractLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentCapacity")
                        .HasColumnType("int");

                    b.Property<int?>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<int>("SpecificationId")
                        .HasColumnType("int");

                    b.Property<int>("UnitGroupId")
                        .HasColumnType("int");

                    b.Property<int>("UnitTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecificationId");

                    b.HasIndex("UnitGroupId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentCapacity = 2,
                            MaxCapacity = 4,
                            SpecificationId = 8,
                            UnitGroupId = 1,
                            UnitTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CurrentCapacity = 0,
                            MaxCapacity = 6,
                            SpecificationId = 1,
                            UnitGroupId = 2,
                            UnitTypeId = 7
                        },
                        new
                        {
                            Id = 3,
                            CurrentCapacity = 3,
                            MaxCapacity = 3,
                            SpecificationId = 1,
                            UnitGroupId = 3,
                            UnitTypeId = 6
                        },
                        new
                        {
                            Id = 4,
                            CurrentCapacity = 1,
                            MaxCapacity = 5,
                            SpecificationId = 1,
                            UnitGroupId = 4,
                            UnitTypeId = 5
                        },
                        new
                        {
                            Id = 5,
                            CurrentCapacity = 7,
                            MaxCapacity = 7,
                            SpecificationId = 1,
                            UnitGroupId = 1,
                            UnitTypeId = 4
                        },
                        new
                        {
                            Id = 6,
                            CurrentCapacity = 23,
                            MaxCapacity = 13,
                            SpecificationId = 1,
                            UnitGroupId = 2,
                            UnitTypeId = 3
                        },
                        new
                        {
                            Id = 7,
                            CurrentCapacity = 1,
                            MaxCapacity = 1,
                            SpecificationId = 1,
                            UnitGroupId = 3,
                            UnitTypeId = 2
                        },
                        new
                        {
                            Id = 8,
                            CurrentCapacity = 0,
                            MaxCapacity = 2,
                            SpecificationId = 1,
                            UnitGroupId = 4,
                            UnitTypeId = 1
                        },
                        new
                        {
                            Id = 9,
                            CurrentCapacity = 3,
                            MaxCapacity = 5,
                            SpecificationId = 1,
                            UnitGroupId = 1,
                            UnitTypeId = 8
                        });
                });

            modelBuilder.Entity("DAL.Models.UnitGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("SpecificationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecificationId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("UnitGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SpecificationId = 10,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            SpecificationId = 11,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            SpecificationId = 12,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            SpecificationId = 13,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("DAL.Models.UnitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Type")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

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
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "tomasfojt@seznam.cz",
                            IsAdmin = false,
                            Password = "1234",
                            Username = "Tomči"
                        },
                        new
                        {
                            Id = 2,
                            Email = "pusinka@seznam.cz",
                            IsAdmin = true,
                            Password = "NeumimSePodepsat",
                            Username = "Janči"
                        },
                        new
                        {
                            Id = 3,
                            Email = "eustac@yahoo.com",
                            IsAdmin = false,
                            Password = "asdf",
                            Username = "Vojta"
                        },
                        new
                        {
                            Id = 4,
                            Email = "hotentot@gmail.cz",
                            IsAdmin = false,
                            Password = "pass123",
                            Username = "Hotentot"
                        },
                        new
                        {
                            Id = 5,
                            Email = "blazeit420@seznam.cz",
                            IsAdmin = false,
                            Password = "qwertz",
                            Username = "Štěpán"
                        },
                        new
                        {
                            Id = 6,
                            Email = "filip@gmail.com",
                            IsAdmin = true,
                            Password = "travicka",
                            Username = "Filip"
                        });
                });

            modelBuilder.Entity("EquipmentUnit", b =>
                {
                    b.Property<int>("AvailableEquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.HasKey("AvailableEquipmentId", "UnitsId");

                    b.HasIndex("UnitsId");

                    b.ToTable("UnitEquipment");
                });

            modelBuilder.Entity("DAL.Models.Photo", b =>
                {
                    b.HasOne("DAL.Models.Unit", null)
                        .WithMany("Photos")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Unit");
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

                    b.Navigation("Address");

                    b.Navigation("Color");
                });

            modelBuilder.Entity("DAL.Models.Unit", b =>
                {
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

                    b.Navigation("Specification");

                    b.Navigation("UnitGroup");

                    b.Navigation("UnitType");
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

                    b.Navigation("Specification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EquipmentUnit", b =>
                {
                    b.HasOne("DAL.Models.Equipment", null)
                        .WithMany()
                        .HasForeignKey("AvailableEquipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.Unit", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("DAL.Models.UnitGroup", b =>
                {
                    b.Navigation("Units");
                });

            modelBuilder.Entity("DAL.Models.UnitType", b =>
                {
                    b.Navigation("Units");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("UnitGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
