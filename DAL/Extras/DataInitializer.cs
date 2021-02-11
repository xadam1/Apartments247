using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Extras
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder builder)
        {
            #region Colors
            builder.Entity<Color>().HasData
            (
                new Color() { Id = 1, Name = "Best" },
                new Color() { Id = 2, Name = "Black" },
                new Color() { Id = 3, Name = "Green" },
                new Color() { Id = 4, Name = "Red" },
                new Color() { Id = 5, Name = "Orange" },
                new Color() { Id = 6, Name = "Yellow" },
                new Color() { Id = 7, Name = "Brown" },
                new Color() { Id = 8, Name = "Purple" },
                new Color() { Id = 9, Name = "Violet" },
                new Color() { Id = 10, Name = "Pink" },
                new Color() { Id = 11, Name = "Salmon" },
                new Color() { Id = 12, Name = "Khaki" },
                new Color() { Id = 13, Name = "Blue" }
            );
            #endregion

            #region Address
            /*
            builder.Entity<Address>().HasData
            (
                new Address()
                {
                    Id = 1,
                    State = "Česká Republika",
                    City = "Brno",
                    Street = "Leitnerova",
                    Number = "679/6",
                    Zip = "602 00"
                },
                new Address()
                {
                    Id = 2,
                    State = "Slovensko",
                    City = "Bratislava",
                    Street = "Hnojová",
                    Number = "4",
                    Zip = "00 11 22"
                },
                new Address()
                {
                    Id = 3,
                    State = "Polsko",
                    City = "Varšava",
                    Street = "U Lesa",
                    Number = "13",
                    Zip = "314 52"
                },
                new Address()
                {
                    Id = 4,
                    State = "Maďarsko",
                    City = "Budapešť",
                    Street = "Křovácká",
                    Number = "8",
                    Zip = "451 732"
                },
                new Address()
                {
                    Id = 5,
                    State = "Německo",
                    City = "Berlín",
                    Street = "Bedřicha Šubčíka",
                    Number = "151",
                    Zip = "38 729"
                },
                new Address()
                {
                    Id = 6,
                    State = "Jugoslávie",
                    City = "Bělehrad",
                    Street = "Zámečnická",
                    Number = "3",
                    Zip = "44 55"
                },
                new Address()
                {
                    Id = 7,
                    State = "Rakousko",
                    City = "Vídeň",
                    Street = "Václavská",
                    Number = "3",
                    Zip = "44 55"
                },
                new Address()
                {
                    Id = 8,
                    State = "Slovinsko",
                    City = "Lublaň",
                    Street = "Mečová",
                    Number = "3",
                    Zip = "44 55"
                },
                new Address()
                {
                    Id = 9,
                    State = "Španělsko",
                    City = "Madrid",
                    Street = "Kozí",
                    Number = "3",
                    Zip = "44 55"
                },
                new Address()
                {
                    Id = 10,
                    State = "Portugalsko",
                    City = "Lisabon",
                    Street = "Kobližná",
                    Number = "3",
                    Zip = "44 55"
                },
                new Address()
                {
                    Id = 11,
                    State = "Itálie",
                    City = "Řím",
                    Street = "Dominikánská",
                    Number = "3",
                    Zip = "44 55"
                },
                new Address()
                {
                    Id = 12,
                    State = "Nizozemsko",
                    City = "Amsterdam",
                    Street = "Botanická",
                    Number = "3",
                    Zip = "44 55"
                },
                new Address()
                {
                    Id = 13,
                    State = "Francie",
                    City = "Paříž",
                    Street = "Hybešova",
                    Number = "3",
                    Zip = "44 55"
                }
            );
            */

            #endregion

            #region Equipment
            builder.Entity<Equipment>().HasData
            (
                new Equipment()
                {
                    Id = 1,
                    Type = "Lednička"
                },
                new Equipment()
                {
                    Id = 2,
                    Type = "Pračka"
                },
                new Equipment()
                {
                    Id = 3,
                    Type = "Sušička"
                },
                new Equipment()
                {
                    Id = 4,
                    Type = "Plynová maska"
                },
                new Equipment()
                {
                    Id = 5,
                    Type = "Pouta, bičíky a LaTeXový obleček"
                },
                new Equipment()
                {
                    Id = 6,
                    Type = "Žehlicí prkno"
                },
                new Equipment()
                {
                    Id = 7,
                    Type = "Topinkovač"
                },
                new Equipment()
                {
                    Id = 8,
                    Type = "Mikrovlnka"
                },
                new Equipment()
                {
                    Id = 9,
                    Type = "Kolíčky na prádlo"
                },
                new Equipment()
                {
                    Id = 10,
                    Type = "Ptačí budka"
                }
            );
            #endregion

            #region Specification
            /*
            builder.Entity<Specification>().HasData
            (
                new Specification()
                {
                    Id = 1,
                    Name = "Leitnerka",
                    ColorId = 13,
                    Note = "Obyčejný byt",
                    AddressId = 1
                },
                new Specification()
                {
                    Id = 2,
                    Name = "Prostřední byt",
                    ColorId = 12,
                    Note = "4. patro",
                    AddressId = 2
                },
                new Specification()
                {
                    Id = 3,
                    Name = "Byt 13",
                    ColorId = 11,
                    Note = "Sousedi",
                    AddressId = 3
                },
                new Specification()
                {
                    Id = 4,
                    Name = "D1",
                    ColorId = 10,
                    Note = "Mučírna",
                    AddressId = 4
                },
                new Specification()
                {
                    Id = 5,
                    Name = "B311",
                    ColorId = 9,
                    Note = "Počítačová učebna",
                    AddressId = 5
                },
                new Specification()
                {
                    Id = 6,
                    Name = "Hliněného kabinet",
                    ColorId = 8,
                    Note = "Hliňasovo království",
                    AddressId = 6
                },
                new Specification()
                {
                    Id = 7,
                    Name = "Tomčiho chata",
                    ColorId = 7,
                    Note = "Tady bylo vyhuleno mnoho trávy",
                    AddressId = 7
                },
                new Specification()
                {
                    Id = 8,
                    Name = "Tomčiho dětský pokoj",
                    ColorId = 6,
                    Note = "Je v něm spousta plyšáků",
                    AddressId = 8
                },
                new Specification()
                {
                    Id = 9,
                    Name = "Jančiho dům",
                    ColorId = 5,
                    Note = "Rodinný dům s bazénem",
                    AddressId = 9
                },
                new Specification()
                {
                    Id = 10,
                    Name = "Tomčiho majetek",
                    ColorId = 4,
                    Note = "Tady je Krakonošovo",
                    AddressId = 10
                },
                new Specification()
                {
                    Id = 11,
                    Name = "Fakulta Informatiky",
                    ColorId = 3,
                    Note = "Všemi nenáviděná budova",
                    AddressId = 11
                },
                new Specification()
                {
                    Id = 12,
                    Name = "Jančiho domeček",
                    ColorId = 2,
                    Note = "A tady žije El Jančitas",
                    AddressId = 12
                },
                new Specification()
                {
                    Id = 13,
                    Name = "Vojtův domeček",
                    ColorId = 1,
                    Note = "Tohle všechno mi patří",
                    AddressId = 13
                }
            );
            */
            #endregion

            #region User
            /*
            builder.Entity<User>().HasData
            (
                new User()
                {
                    Id = 1,
                    Username = "Tomči",
                    Password = "1234",
                    IsAdmin = false,
                    Email = "tomasfojt@seznam.cz"
                },
                new User()
                {
                    Id = 2,
                    Username = "Janči",
                    Password = "NeumimSePodepsat",
                    IsAdmin = true,
                    Email = "pusinka@seznam.cz"
                },
                new User()
                {
                    Id = 3,
                    Username = "Vojta",
                    Password = "asdf",
                    IsAdmin = false,
                    Email = "eustac@yahoo.com"
                },
                new User()
                {
                    Id = 4,
                    Username = "Hotentot",
                    Password = "pass123",
                    IsAdmin = false,
                    Email = "hotentot@gmail.cz"
                },
                new User()
                {
                    Id = 5,
                    Username = "Štěpán",
                    Password = "qwertz",
                    IsAdmin = false,
                    Email = "blazeit420@seznam.cz"
                },
                new User()
                {
                    Id = 6,
                    Username = "Filip",
                    Password = "travicka",
                    IsAdmin = true,
                    Email = "filip@gmail.com"
                }
            );
            */
            #endregion

            #region UnitGroups
            /*
            builder.Entity<UnitGroup>().HasData
            (
                // Tomčiho majetek
                new UnitGroup()
                {
                    Id = 1,
                    SpecificationId = 10,
                    UserId = 1
                },
                // Škola
                new UnitGroup()
                {
                    Id = 2,
                    SpecificationId = 11,
                    UserId = 2
                },
                // Jančiho majetek
                new UnitGroup()
                {
                    Id = 3,
                    SpecificationId = 12,
                    UserId = 3
                },
                // Vojtův majetek
                new UnitGroup()
                {
                    Id = 4,
                    SpecificationId = 13,
                    UserId = 4
                }
            );
            */
            #endregion

            #region UnitType
            builder.Entity<UnitType>().HasData
            (
                new UnitType()
                {
                    Id = 1,
                    Type = "Byt"
                },
                new UnitType()
                {
                    Id = 2,
                    Type = "Řadový dům"
                },
                new UnitType()
                {
                    Id = 3,
                    Type = "Dům se zahradou"
                },
                new UnitType()
                {
                    Id = 4,
                    Type = "Garáž"
                },
                new UnitType()
                {
                    Id = 5,
                    Type = "Školní třída"
                },
                new UnitType()
                {
                    Id = 6,
                    Type = "Rodinná hrobka"
                },
                new UnitType()
                {
                    Id = 7,
                    Type = "Parkovací místo"
                },
                new UnitType()
                {
                    Id = 8,
                    Type = "Autobusová zastávka"
                }
            );
            #endregion

            #region Units
            /*
            builder.Entity<Unit>().HasData
            (
                new Unit()
                {
                    Id = 1,
                    CurrentCapacity = 2,
                    MaxCapacity = 4,
                    UnitTypeId = 1,
                    SpecificationId = 8,
                    ContractId = 1,
                    UnitGroupId = 1
                },
                new Unit()
                {
                    Id = 2,
                    CurrentCapacity = 0,
                    MaxCapacity = 6,
                    UnitTypeId = 7,
                    SpecificationId = 1,
                    ContractId = 1,
                    UnitGroupId = 2
                },
                new Unit()
                {
                    Id = 3,
                    CurrentCapacity = 3,
                    MaxCapacity = 3,
                    UnitTypeId = 6,
                    SpecificationId = 1,
                    ContractId = 1,
                    UnitGroupId = 3
                },
                new Unit()
                {
                    Id = 4,
                    CurrentCapacity = 1,
                    MaxCapacity = 5,
                    UnitTypeId = 5,
                    SpecificationId = 1,
                    ContractId = 1,
                    UnitGroupId = 4
                },
                new Unit()
                {
                    Id = 5,
                    CurrentCapacity = 7,
                    MaxCapacity = 7,
                    UnitTypeId = 4,
                    SpecificationId = 1,
                    ContractId = 1,
                    UnitGroupId = 1
                },
                new Unit()
                {
                    Id = 6,
                    CurrentCapacity = 23,
                    MaxCapacity = 13,
                    UnitTypeId = 3,
                    SpecificationId = 1,
                    ContractId = 1,
                    UnitGroupId = 2
                },
                new Unit()
                {
                    Id = 7,
                    CurrentCapacity = 1,
                    MaxCapacity = 1,
                    UnitTypeId = 2,
                    SpecificationId = 1,
                    ContractId = 1,
                    UnitGroupId = 3
                },
                new Unit()
                {
                    Id = 8,
                    CurrentCapacity = 0,
                    MaxCapacity = 2,
                    UnitTypeId = 1,
                    SpecificationId = 1,
                    ContractId = 1,
                    UnitGroupId = 4
                },
                new Unit()
                {
                    Id = 9,
                    CurrentCapacity = 3,
                    MaxCapacity = 5,
                    UnitTypeId = 8,
                    SpecificationId = 1,
                    ContractId = 1,
                    UnitGroupId = 1
                }
            );
            */
            #endregion

            #region Photo
            /*
            builder.Entity<Photo>().HasData
            (
                new Photo()
                {
                    Id = 1,
                    Name = "Obývák",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Krásná fotografie obýváku",
                    UnitId = 1
                },
                new Photo()
                {
                    Id = 2,
                    Name = "Schody do sklepa",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Janči odnášející mrtvolu do sklepa",
                    UnitId = 2
                },
                new Photo()
                {
                    Id = 3,
                    Name = "Kuchyně",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Aparatura k vaření perníku",
                    UnitId = 3
                },
                new Photo()
                {
                    Id = 4,
                    Name = "Okno",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Výhled z okna",
                    UnitId = 4
                },
                new Photo()
                {
                    Id = 5,
                    Name = "Hřiště",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Dětské hřiště před domem",
                    UnitId = 5
                },
                new Photo()
                {
                    Id = 6,
                    Name = "Hladomorna",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Zde se trápí hladem zlobivé děti",
                    UnitId = 6
                },
                new Photo()
                {
                    Id = 7,
                    Name = "Hotelový pokoj",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Pokoj s postelí a nočním stolkem",
                    UnitId = 7
                },
                new Photo()
                {
                    Id = 8,
                    Name = "Rozhledna",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Výhled na široké okolí",
                    UnitId = 8
                },
                new Photo()
                {
                    Id = 9,
                    Name = "Kovárna",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Kovář kovající podkovu",
                    UnitId = 9
                }
            );
            */
            #endregion

            #region Cost
            /*
            builder.Entity<Cost>().HasData
            (
                new Cost
                {
                    Id = 1,
                    Name = "Nájem",
                    Price = 20000,
                    CostType = CostType.Income,
                    Date = DateTime.Now,
                    UnitId = 1
                },
                new Cost
                {
                    Id = 2,
                    Name = "Podnájem",
                    Price = 10000,
                    CostType = CostType.Income,
                    Date = DateTime.Now,
                    UnitId = 2
                },
                new Cost
                {
                    Id = 3,
                    Name = "Cena za vodu",
                    Price = 2000,
                    CostType = CostType.Income,
                    Date = DateTime.Now,
                    UnitId = 3
                },
                new Cost
                {
                    Id = 4,
                    Name = "Cena za elektřinu",
                    Price = 1500,
                    CostType = CostType.Income,
                    Date = DateTime.Now,
                    UnitId = 4
                },
                new Cost
                {
                    Id = 5,
                    Name = "Oprava pračky",
                    Price = 12000,
                    CostType = CostType.Outcome,
                    Date = DateTime.Now,
                    UnitId = 5
                },
                new Cost
                {
                    Id = 6,
                    Name = "Nová televize",
                    Price = 25000,
                    CostType = CostType.Outcome,
                    Date = DateTime.Now,
                    UnitId = 6
                },
                new Cost
                {
                    Id = 7,
                    Name = "Výmalba obyvacího pokoje",
                    Price = 11000,
                    CostType = CostType.Outcome,
                    Date = DateTime.Now,
                    UnitId = 7
                },
                new Cost
                {
                    Id = 8,
                    Name = "Přestavba kuchyně",
                    Price = 27000,
                    CostType = CostType.Outcome,
                    Date = DateTime.Now,
                    UnitId = 8
                },
                new Cost
                {
                    Id = 9,
                    Name = "Nová varna na perník",
                    Price = 30000,
                    CostType = CostType.Outcome,
                    Date = DateTime.Now,
                    UnitId = 9
                },
                new Cost
                {
                    Id = 10,
                    Name = "Televizní kanály pro dospělé",
                    Price = 1000,
                    CostType = CostType.Outcome,
                    Date = DateTime.Now,
                    UnitId = 1
                },
                new Cost
                {
                    Id = 11,
                    Name = "Zápasy s dětskými otroky",
                    Price = 69000,
                    CostType = CostType.Income,
                    Date = DateTime.Now,
                    UnitId = 2
                }
            );
            */
            #endregion

            #region UnitEquipment
            /*
            builder.Entity<UnitEquipment>().HasData
            (
                new UnitEquipment
                {
                    Id = 1,
                    UnitId = 1,
                    EquipmentId = 1
                },
                new UnitEquipment
                {
                    Id = 2,
                    UnitId = 2,
                    EquipmentId = 2
                },
                new UnitEquipment
                {
                    Id = 3,
                    UnitId = 3,
                    EquipmentId = 3
                },
                new UnitEquipment
                {
                    Id = 4,
                    UnitId = 4,
                    EquipmentId = 4
                },
                new UnitEquipment
                {
                    Id = 5,
                    UnitId = 5,
                    EquipmentId = 5
                },
                new UnitEquipment
                {
                    Id = 6,
                    UnitId = 6,
                    EquipmentId = 6
                },
                new UnitEquipment
                {
                    Id = 7,
                    UnitId = 7,
                    EquipmentId = 7
                },
                new UnitEquipment
                {
                    Id = 8,
                    UnitId = 8,
                    EquipmentId = 8
                },
                new UnitEquipment
                {
                    Id = 9,
                    UnitId = 9,
                    EquipmentId = 9
                },
                new UnitEquipment
                {
                    Id = 10,
                    UnitId = 1,
                    EquipmentId = 5
                },
                new UnitEquipment
                {
                    Id = 11,
                    UnitId = 2,
                    EquipmentId = 7
                },
                new UnitEquipment
                {
                    Id = 12,
                    UnitId = 3,
                    EquipmentId = 4
                },
                new UnitEquipment
                {
                    Id = 13,
                    UnitId = 4,
                    EquipmentId = 8
                }
            );
            */
            #endregion

            #region Contract
            /*
            builder.Entity<Contract>().HasData
            (
                new Contract
                {
                    Id = 1,
                    Name = "test.pdf",
                    Content = null
                }
            );
            */
            #endregion
        }
    }
}