using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SqliteInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(maxLength: 64, nullable: false),
                    Number = table.Column<string>(maxLength: 64, nullable: false),
                    Zip = table.Column<string>(maxLength: 64, nullable: true),
                    State = table.Column<string>(maxLength: 64, nullable: true),
                    City = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    Username = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specifications_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    SpecificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitGroups_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrentCapacity = table.Column<int>(nullable: true),
                    MaxCapacity = table.Column<int>(nullable: true),
                    SpecificationId = table.Column<int>(nullable: false),
                    UnitTypeId = table.Column<int>(nullable: false),
                    UnitGroupId = table.Column<int>(nullable: false),
                    ContractId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_UnitGroups_UnitGroupId",
                        column: x => x.UnitGroupId,
                        principalTable: "UnitGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyCost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Price = table.Column<int>(nullable: false),
                    CostType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyCost_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Path = table.Column<string>(maxLength: 512, nullable: true),
                    DateTimeUploaded = table.Column<DateTime>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UnitId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitEquipment_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitEquipment_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 1, "Brno", "679/6", "Česká Republika", "Leitnerova", "602 00" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 13, "Paříž", "3", "Francie", "Hybešova", "44 55" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 12, "Amsterdam", "3", "Nizozemsko", "Botanická", "44 55" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 11, "Řím", "3", "Itálie", "Dominikánská", "44 55" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 9, "Madrid", "3", "Španělsko", "Kozí", "44 55" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 8, "Lublaň", "3", "Slovinsko", "Mečová", "44 55" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 10, "Lisabon", "3", "Portugalsko", "Kobližná", "44 55" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 6, "Bělehrad", "3", "Jugoslávie", "Zámečnická", "44 55" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 5, "Berlín", "151", "Německo", "Bedřicha Šubčíka", "38 729" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 4, "Budapešť", "8", "Maďarsko", "Křovácká", "451 732" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 3, "Varšava", "13", "Polsko", "U Lesa", "314 52" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 2, "Bratislava", "4", "Slovensko", "Hnojová", "00 11 22" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 7, "Vídeň", "3", "Rakousko", "Václavská", "44 55" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Purple" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Khaki" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Salmon" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Pink" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Violet" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Brown" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Blue" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Orange" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Red" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Green" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Black" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Best" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Yellow" });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "Id", "Content", "Name" },
                values: new object[] { 1, null, "test.pdf" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[] { 10, "Ptačí budka" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[] { 8, "Mikrovlnka" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[] { 7, "Topinkovač" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[] { 6, "Žehlicí prkno" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[] { 9, "Kolíčky na prádlo" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[] { 4, "Plynová maska" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Sušička" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Pračka" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Lednička" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[] { 5, "Pouta, bičíky a LaTeXový obleček" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 8, "Autobusová zastávka" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 7, "Parkovací místo" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 6, "Rodinná hrobka" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 5, "Školní třída" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Dům se zahradou" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Řadový dům" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Byt" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 4, "Garáž" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[] { 5, "blazeit420@seznam.cz", false, "qwertz", "Štěpán" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[] { 1, "tomasfojt@seznam.cz", false, "1234", "Tomči" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[] { 2, "pusinka@seznam.cz", true, "NeumimSePodepsat", "Janči" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[] { 3, "eustac@yahoo.com", false, "asdf", "Vojta" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[] { 4, "hotentot@gmail.cz", false, "pass123", "Hotentot" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[] { 6, "filip@gmail.com", true, "travicka", "Filip" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 13, 13, 1, "Vojtův domeček", "Tohle všechno mi patří" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 12, 12, 2, "Jančiho domeček", "A tady žije El Jančitas" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 11, 11, 3, "Fakulta Informatiky", "Všemi nenáviděná budova" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 10, 10, 4, "Tomčiho majetek", "Tady je Krakonošovo" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 9, 9, 5, "Jančiho dům", "Rodinný dům s bazénem" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 8, 8, 6, "Tomčiho dětský pokoj", "Je v něm spousta plyšáků" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 7, 7, 7, "Tomčiho chata", "Tady bylo vyhuleno mnoho trávy" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 6, 6, 8, "Hliněného kabinet", "Hliňasovo království" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 5, 5, 9, "B311", "Počítačová učebna" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 4, 4, 10, "D1", "Mučírna" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 3, 3, 11, "Byt 13", "Sousedi" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 2, 2, 12, "Prostřední byt", "4. patro" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 1, 1, 13, "Leitnerka", "Obyčejný byt" });

            migrationBuilder.InsertData(
                table: "UnitGroups",
                columns: new[] { "Id", "SpecificationId", "UserId" },
                values: new object[] { 4, 13, 4 });

            migrationBuilder.InsertData(
                table: "UnitGroups",
                columns: new[] { "Id", "SpecificationId", "UserId" },
                values: new object[] { 3, 12, 3 });

            migrationBuilder.InsertData(
                table: "UnitGroups",
                columns: new[] { "Id", "SpecificationId", "UserId" },
                values: new object[] { 2, 11, 2 });

            migrationBuilder.InsertData(
                table: "UnitGroups",
                columns: new[] { "Id", "SpecificationId", "UserId" },
                values: new object[] { 1, 10, 1 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractId", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 4, 1, 1, 5, 1, 4, 5 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractId", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 8, 1, 0, 2, 1, 4, 1 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractId", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 3, 1, 3, 3, 1, 3, 6 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractId", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 7, 1, 1, 1, 1, 3, 2 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractId", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 2, 1, 0, 6, 1, 2, 7 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractId", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 6, 1, 23, 13, 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractId", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 1, 1, 2, 4, 8, 1, 1 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractId", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 5, 1, 7, 7, 1, 1, 4 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractId", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 9, 1, 3, 5, 1, 1, 8 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 4, 0, new DateTime(2021, 2, 5, 16, 9, 54, 738, DateTimeKind.Local).AddTicks(4481), "Cena za elektřinu", 1500, 4 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 9, 1, new DateTime(2021, 2, 5, 16, 9, 54, 738, DateTimeKind.Local).AddTicks(4500), "Nová varna na perník", 30000, 9 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 5, 1, new DateTime(2021, 2, 5, 16, 9, 54, 738, DateTimeKind.Local).AddTicks(4485), "Oprava pračky", 12000, 5 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 8, 1, new DateTime(2021, 2, 5, 16, 9, 54, 738, DateTimeKind.Local).AddTicks(4496), "Přestavba kuchyně", 27000, 8 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 10, 1, new DateTime(2021, 2, 5, 16, 9, 54, 738, DateTimeKind.Local).AddTicks(4503), "Televizní kanály pro dospělé", 1000, 1 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 3, 0, new DateTime(2021, 2, 5, 16, 9, 54, 738, DateTimeKind.Local).AddTicks(4473), "Cena za vodu", 2000, 3 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 1, 0, new DateTime(2021, 2, 5, 16, 9, 54, 733, DateTimeKind.Local).AddTicks(5333), "Nájem", 20000, 1 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 6, 1, new DateTime(2021, 2, 5, 16, 9, 54, 738, DateTimeKind.Local).AddTicks(4489), "Nová televize", 25000, 6 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 7, 1, new DateTime(2021, 2, 5, 16, 9, 54, 738, DateTimeKind.Local).AddTicks(4493), "Výmalba obyvacího pokoje", 11000, 7 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 11, 0, new DateTime(2021, 2, 5, 16, 9, 54, 738, DateTimeKind.Local).AddTicks(4507), "Zápasy s dětskými otroky", 69000, 2 });

            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[] { 2, 0, new DateTime(2021, 2, 5, 16, 9, 54, 738, DateTimeKind.Local).AddTicks(4413), "Podnájem", 10000, 2 });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "DateTimeUploaded", "Description", "Name", "Path", "UnitId" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dětské hřiště před domem", "Hřiště", "/", 5 });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "DateTimeUploaded", "Description", "Name", "Path", "UnitId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krásná fotografie obýváku", "Obývák", "/", 1 });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "DateTimeUploaded", "Description", "Name", "Path", "UnitId" },
                values: new object[] { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zde se trápí hladem zlobivé děti", "Hladomorna", "/", 6 });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "DateTimeUploaded", "Description", "Name", "Path", "UnitId" },
                values: new object[] { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kovář kovající podkovu", "Kovárna", "/", 9 });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "DateTimeUploaded", "Description", "Name", "Path", "UnitId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janči odnášející mrtvolu do sklepa", "Schody do sklepa", "/", 2 });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "DateTimeUploaded", "Description", "Name", "Path", "UnitId" },
                values: new object[] { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pokoj s postelí a nočním stolkem", "Hotelový pokoj", "/", 7 });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "DateTimeUploaded", "Description", "Name", "Path", "UnitId" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Výhled z okna", "Okno", "/", 4 });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "DateTimeUploaded", "Description", "Name", "Path", "UnitId" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aparatura k vaření perníku", "Kuchyně", "/", 3 });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "DateTimeUploaded", "Description", "Name", "Path", "UnitId" },
                values: new object[] { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Výhled na široké okolí", "Rozhledna", "/", 8 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 3, 3, 3 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 6, 6, 6 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 11, 7, 2 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 8, 8, 8 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 7, 7, 7 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 10, 5, 1 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 13, 8, 4 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 4, 4, 4 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 5, 5, 5 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 12, 4, 3 });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[] { 9, 9, 9 });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCost_UnitId",
                table: "MonthlyCost",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UnitId",
                table: "Photo",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_AddressId",
                table: "Specifications",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ColorId",
                table: "Specifications",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitEquipment_EquipmentId",
                table: "UnitEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitEquipment_UnitId",
                table: "UnitEquipment",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitGroups_SpecificationId",
                table: "UnitGroups",
                column: "SpecificationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitGroups_UserId",
                table: "UnitGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ContractId",
                table: "Units",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_SpecificationId",
                table: "Units",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitGroupId",
                table: "Units",
                column: "UnitGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units",
                column: "UnitTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyCost");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "UnitEquipment");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "UnitGroups");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
