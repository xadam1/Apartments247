using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Extras;

namespace DAL.Extras
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder builder)
        {
            #region Address            
            // Address
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
                    Id = 4,
                    State = "Německo",
                    City = "Berlín",
                    Street = "Bedřicha Šubčíka",
                    Number = "151",
                    Zip = "38 729"
                },
                new Address()
                {
                    Id = 4,
                    State = "Jugoslávie",
                    City = "Bělehrad",
                    Street = "Zámečnická",
                    Number = "3",
                    Zip = "44 55"
                }
            );
            #endregion

            #region Equipment
            // Equipment
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
            
            #region Photo
            // Photo
            builder.Entity<Photo>().HasData
            (
                new Photo()
                {
                    Id = 1,
                    Name = "Obývák",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Krásná fotografie obýváku",
                },
                new Photo()
                {
                    Id = 2,
                    Name = "Schody do sklepa",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Janči odnášející mrtvolu do sklepa",
                },
                new Photo()
                {
                    Id = 3,
                    Name = "Kuchyně",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Aparatura k vaření perníku",
                },
                new Photo()
                {
                    Id = 4,
                    Name = "Okno",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Výhled z okna",
                },
                new Photo()
                {
                    Id = 5,
                    Name = "Hřiště",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Dětské hřiště před domem",
                },
                new Photo()
                {
                    Id = 6,
                    Name = "Hladomorna",
                    Path = "/",
                    DateTimeUploaded = System.DateTime.MinValue,
                    Description = "Zde se trápí hladem zlobivé děti"
                }
            );
            #endregion

            #region Specification
            // Specification
            builder.Entity<Specification>().HasData
            (
                new Specification()
                {
                    Id = 1,
                    Name = "Leitnerka",
                    Color = Color.Best,
                    Note = "Obyčejný byt",
                    AddressId = 1
                },
                new Specification()
                {
                    Id = 2,
                    Name = "Prostřední byt",
                    Color = Color.Black,
                    Note = "4. patro",
                    AddressId = 2
                },
                new Specification()
                {
                    Id = 3,
                    Name = "Byt 13",
                    Color = Color.Blue,
                    Note = "Sousedi",
                    AddressId = 3
                },
                new Specification()
                {
                    Id = 4,
                    Name = "D1",
                    Color = Color.Brown,
                    Note = "Mučírna",
                    AddressId = 4
                },
                new Specification()
                {
                    Id = 5,
                    Name = "B311",
                    Color = Color.Green,
                    Note = "Počítačová učebna",
                    AddressId = 5
                },
                new Specification()
                {
                    Id = 6,
                    Name = "Hliněného kabinet",
                    Color = Color.Khaki,
                    Note = "Hliňasovo království",
                    AddressId = 6
                },
                new Specification()
                {
                    Id = 7,
                    Name = "Tomčiho chata",
                    Color = Color.Orange,
                    Note = "Tady bylo vyhuleno mnoho trávy",
                    AddressId = 7
                },
                new Specification()
                {
                    Id = 8,
                    Name = "Tomčiho dětský pokoj",
                    Color = Color.Pink,
                    Note = "Je v něm spousta plyšáků",
                    AddressId = 8
                },
                new Specification()
                {
                    Id = 9,
                    Name = "Jančiho dům",
                    Color = Color.Purple,
                    Note = "Rodinný dům s bazénem",
                    AddressId = 9
                },
                new Specification()
                {
                    Id = 10,
                    Name = "Tomčiho majetek",
                    Color = Color.Red,
                    Note = "Tady je Krakonošovo",
                    AddressId = 10
                },
                new Specification()
                {
                    Id = 11,
                    Name = "Fakulta Informatiky",
                    Color = Color.Salmon,
                    Note = "Všemi nenáviděná budova",
                    AddressId = 11
                },
                new Specification()
                {
                    Id = 12,
                    Name = "Jančiho domeček",
                    Color = Color.Violet,
                    Note = "A tady žije El Jančitas",
                    AddressId = 12
                },
                new Specification()
                {
                    Id = 13,
                    Name = "Vojtův domeček",
                    Color = Color.Yellow,
                    Note = "Tohle všechno mi patří",
                    AddressId = 13
                }
            );
            #endregion

            #region UnitGroups
            // UnitGroups
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
                    UserId = 5
                },
                // Jančiho majetek
                new UnitGroup()
                {
                    Id = 3,
                    SpecificationId = 12,
                    UserId = 2
                },
                // Vojtův majetek
                new UnitGroup()
                {
                    Id = 4,
                    SpecificationId = 13,
                    UserId = 3
                }
            );
            #endregion

            #region Units
            builder.Entity<Unit>().HasData
            (
                new Unit()
                {
                    Id = 1,
                    CurrentCapacity = 2,
                    MaxCapacity = 4,
                    UnitTypeId = 1,
                    SpecificationId = 8,
                    ContractLink = null
                },
                new Unit()
                {
                    Id = 2,
                    CurrentCapacity = 0,
                    MaxCapacity = 6,
                    UnitTypeId = 7,
                    SpecificationId = 1,
                    ContractLink = null
                },
                new Unit()
                {
                    Id = 3,
                    CurrentCapacity = 3,
                    MaxCapacity = 3,
                    UnitTypeId = 6,
                    SpecificationId = 1,
                    ContractLink = null
                },
                new Unit()
                {
                    Id = 4,
                    CurrentCapacity = 1,
                    MaxCapacity = 5,
                    UnitTypeId = 5,
                    SpecificationId = 1,
                    ContractLink = null
                },
                new Unit()
                {
                    Id = 5,
                    CurrentCapacity = 7,
                    MaxCapacity = 7,
                    UnitTypeId = 4,
                    SpecificationId = 1,
                    ContractLink = null
                },
                new Unit()
                {
                    Id = 6,
                    CurrentCapacity = 23,
                    MaxCapacity = 13,
                    UnitTypeId = 3,
                    SpecificationId = 1,
                    ContractLink = null
                },
                new Unit()
                {
                    Id = 7,
                    CurrentCapacity = 1,
                    MaxCapacity = 1,
                    UnitTypeId = 2,
                    SpecificationId = 1,
                    ContractLink = null
                },
                new Unit()
                {
                    Id = 8,
                    CurrentCapacity = 0,
                    MaxCapacity = 2,
                    UnitTypeId = 1,
                    SpecificationId = 1,
                    ContractLink = null
                },
                new Unit()
                {
                    Id = 9,
                    CurrentCapacity = 3,
                    MaxCapacity = 5,
                    UnitTypeId = 8,
                    SpecificationId = 1,
                    ContractLink = null
                }
            );
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

            #region User
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
            #endregion
            
            // Unit With Equipment
            //builder.Entity<Unit>()
            //    .HasData();
        }
    }
}