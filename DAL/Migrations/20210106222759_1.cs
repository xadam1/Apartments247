using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    State = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    City = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SpecificationId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentCapacity = table.Column<int>(type: "int", nullable: true),
                    MaxCapacity = table.Column<int>(type: "int", nullable: true),
                    SpecificationId = table.Column<int>(type: "int", nullable: false),
                    UnitTypeId = table.Column<int>(type: "int", nullable: false),
                    UnitGroupId = table.Column<int>(type: "int", nullable: false),
                    ContractLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
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
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DateTimeUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UnitId1 = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Photo_Units_UnitId1",
                        column: x => x.UnitId1,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitEquipment",
                columns: table => new
                {
                    AvailableEquipmentId = table.Column<int>(type: "int", nullable: false),
                    UnitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitEquipment", x => new { x.AvailableEquipmentId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_UnitEquipment_Equipment_AvailableEquipmentId",
                        column: x => x.AvailableEquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitEquipment_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[,]
                {
                    { 1, "Brno", "679/6", "Česká Republika", "Leitnerova", "602 00" },
                    { 13, "Paříž", "3", "Francie", "Hybešova", "44 55" },
                    { 12, "Amsterdam", "3", "Nizozemsko", "Botanická", "44 55" },
                    { 11, "Řím", "3", "Itálie", "Dominikánská", "44 55" },
                    { 9, "Madrid", "3", "Španělsko", "Kozí", "44 55" },
                    { 8, "Lublaň", "3", "Slovinsko", "Mečová", "44 55" },
                    { 10, "Lisabon", "3", "Portugalsko", "Kobližná", "44 55" },
                    { 6, "Bělehrad", "3", "Jugoslávie", "Zámečnická", "44 55" },
                    { 5, "Berlín", "151", "Německo", "Bedřicha Šubčíka", "38 729" },
                    { 4, "Budapešť", "8", "Maďarsko", "Křovácká", "451 732" },
                    { 3, "Varšava", "13", "Polsko", "U Lesa", "314 52" },
                    { 2, "Bratislava", "4", "Slovensko", "Hnojová", "00 11 22" },
                    { 7, "Vídeň", "3", "Rakousko", "Václavská", "44 55" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Purple" },
                    { 13, "Blue" },
                    { 11, "Salmon" },
                    { 10, "Pink" },
                    { 9, "Violet" },
                    { 7, "Brown" },
                    { 12, "Khaki" },
                    { 5, "Orange" },
                    { 4, "Red" },
                    { 3, "Green" },
                    { 2, "Black" },
                    { 1, "Best" },
                    { 6, "Yellow" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 10, "Ptačí budka" },
                    { 8, "Mikrovlnka" },
                    { 7, "Topinkovač" },
                    { 6, "Žehlicí prkno" },
                    { 9, "Kolíčky na prádlo" },
                    { 4, "Plynová maska" },
                    { 3, "Sušička" },
                    { 2, "Pračka" },
                    { 1, "Lednička" },
                    { 5, "Pouta, bičíky a LaTeXový obleček" }
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 8, "Autobusová zastávka" },
                    { 7, "Parkovací místo" },
                    { 6, "Rodinná hrobka" },
                    { 5, "Školní třída" },
                    { 3, "Dům se zahradou" },
                    { 2, "Řadový dům" }
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Byt" },
                    { 4, "Garáž" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[,]
                {
                    { 5, "blazeit420@seznam.cz", false, "qwertz", "Štěpán" },
                    { 1, "tomasfojt@seznam.cz", false, "1234", "Tomči" },
                    { 2, "pusinka@seznam.cz", true, "NeumimSePodepsat", "Janči" },
                    { 3, "eustac@yahoo.com", false, "asdf", "Vojta" },
                    { 4, "hotentot@gmail.cz", false, "pass123", "Hotentot" },
                    { 6, "filip@gmail.com", true, "travicka", "Filip" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[,]
                {
                    { 13, 13, 1, "Vojtův domeček", "Tohle všechno mi patří" },
                    { 12, 12, 2, "Jančiho domeček", "A tady žije El Jančitas" },
                    { 11, 11, 3, "Fakulta Informatiky", "Všemi nenáviděná budova" },
                    { 10, 10, 4, "Tomčiho majetek", "Tady je Krakonošovo" },
                    { 9, 9, 5, "Jančiho dům", "Rodinný dům s bazénem" },
                    { 8, 8, 6, "Tomčiho dětský pokoj", "Je v něm spousta plyšáků" },
                    { 7, 7, 7, "Tomčiho chata", "Tady bylo vyhuleno mnoho trávy" },
                    { 6, 6, 8, "Hliněného kabinet", "Hliňasovo království" },
                    { 5, 5, 9, "B311", "Počítačová učebna" },
                    { 4, 4, 10, "D1", "Mučírna" },
                    { 3, 3, 11, "Byt 13", "Sousedi" },
                    { 2, 2, 12, "Prostřední byt", "4. patro" },
                    { 1, 1, 13, "Leitnerka", "Obyčejný byt" }
                });

            migrationBuilder.InsertData(
                table: "UnitGroups",
                columns: new[] { "Id", "SpecificationId", "UserId" },
                values: new object[,]
                {
                    { 4, 13, 4 },
                    { 3, 12, 3 },
                    { 2, 11, 2 },
                    { 1, 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractLink", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[,]
                {
                    { 4, null, 1, 5, 1, 4, 5 },
                    { 8, null, 0, 2, 1, 4, 1 },
                    { 3, null, 3, 3, 1, 3, 6 },
                    { 7, null, 1, 1, 1, 3, 2 },
                    { 2, null, 0, 6, 1, 2, 7 },
                    { 6, null, 23, 13, 1, 2, 3 },
                    { 1, null, 2, 4, 8, 1, 1 },
                    { 5, null, 7, 7, 1, 1, 4 },
                    { 9, null, 3, 5, 1, 1, 8 }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "DateTimeUploaded", "Description", "Name", "Path", "UnitId", "UnitId1" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Výhled z okna", "Okno", "/", 4, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Výhled na široké okolí", "Rozhledna", "/", 8, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aparatura k vaření perníku", "Kuchyně", "/", 3, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pokoj s postelí a nočním stolkem", "Hotelový pokoj", "/", 7, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janči odnášející mrtvolu do sklepa", "Schody do sklepa", "/", 2, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zde se trápí hladem zlobivé děti", "Hladomorna", "/", 6, null },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krásná fotografie obýváku", "Obývák", "/", 1, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dětské hřiště před domem", "Hřiště", "/", 5, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kovář kovající podkovu", "Kovárna", "/", 9, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UnitId",
                table: "Photo",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UnitId1",
                table: "Photo",
                column: "UnitId1");

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
                name: "IX_UnitEquipment_UnitsId",
                table: "UnitEquipment",
                column: "UnitsId");

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
                name: "Photo");

            migrationBuilder.DropTable(
                name: "UnitEquipment");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Units");

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
