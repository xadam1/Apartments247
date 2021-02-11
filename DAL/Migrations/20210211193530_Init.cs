using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
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
                    table.PrimaryKey("PK_Addresses", x => x.Id);
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
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
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
                        name: "FK_Specifications_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
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
                    MonthlyIncome = table.Column<int>(nullable: false),
                    ContractId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
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
                name: "Costs",
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
                    table.PrimaryKey("PK_Costs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Costs_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
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
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Units_UnitId",
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
                        name: "FK_UnitEquipment_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
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
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Best" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Blue" });

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
                values: new object[] { 8, "Purple" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Violet" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Yellow" });

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
                values: new object[] { 7, "Brown" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 7, "Topinkovač" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 10, "Ptačí budka" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 9, "Kolíčky na prádlo" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 8, "Mikrovlnka" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 6, "Žehlicí prkno" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Sušička" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 4, "Plynová maska" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Pračka" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Lednička" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Type" },
                values: new object[] { 5, "Pouta, bičíky a LaTeXový obleček" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 7, "Parkovací místo" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Byt" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Řadový dům" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Dům se zahradou" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 4, "Garáž" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 5, "Školní třída" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 6, "Rodinná hrobka" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 8, "Autobusová zastávka" });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_UnitId",
                table: "Costs",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UnitId",
                table: "Photos",
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
                name: "Costs");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "UnitEquipment");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "UnitGroups");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
