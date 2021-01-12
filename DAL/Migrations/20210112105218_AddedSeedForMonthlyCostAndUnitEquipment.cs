using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedSeedForMonthlyCostAndUnitEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MonthlyCost",
                columns: new[] { "Id", "CostType", "Date", "Name", "Price", "UnitId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2021, 1, 12, 11, 52, 17, 687, DateTimeKind.Local).AddTicks(2352), "Nájem", 20000, 1 },
                    { 2, 0, new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1856), "Podnájem", 10000, 2 },
                    { 3, 0, new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1914), "Cena za vodu", 2000, 3 },
                    { 4, 0, new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1920), "Cena za elektřinu", 1500, 4 },
                    { 5, 1, new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1924), "Oprava pračky", 12000, 5 },
                    { 6, 1, new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1928), "Nová televize", 25000, 6 },
                    { 7, 1, new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1931), "Výmalba obyvacího pokoje", 11000, 7 },
                    { 8, 1, new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1934), "Přestavba kuchyně", 27000, 8 },
                    { 9, 1, new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1937), "Nová varna na perník", 30000, 9 },
                    { 10, 1, new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1940), "Televizní kanály pro dospělé", 1000, 1 },
                    { 11, 0, new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1943), "Zápasy s dětskými otroky", 69000, 2 }
                });

            migrationBuilder.InsertData(
                table: "UnitEquipment",
                columns: new[] { "Id", "EquipmentId", "UnitId" },
                values: new object[,]
                {
                    { 11, 7, 2 },
                    { 10, 5, 1 },
                    { 9, 9, 9 },
                    { 8, 8, 8 },
                    { 7, 7, 7 },
                    { 1, 1, 1 },
                    { 5, 5, 5 },
                    { 4, 4, 4 },
                    { 3, 3, 3 },
                    { 2, 2, 2 },
                    { 12, 4, 3 },
                    { 6, 6, 6 },
                    { 13, 8, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UnitEquipment",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
