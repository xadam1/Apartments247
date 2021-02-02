using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ContractTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractLink",
                table: "Units");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "Id", "Content", "Name" },
                values: new object[] { 1, null, "test.pdf" });

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 504, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 507, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 507, DateTimeKind.Local).AddTicks(1459));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 507, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 507, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 507, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 507, DateTimeKind.Local).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 507, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 507, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 507, DateTimeKind.Local).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2021, 2, 2, 15, 12, 47, 507, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContractId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "ContractId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "ContractId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "ContractId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5,
                column: "ContractId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6,
                column: "ContractId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7,
                column: "ContractId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8,
                column: "ContractId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9,
                column: "ContractId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Units_ContractId",
                table: "Units",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Contract_ContractId",
                table: "Units",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Contract_ContractId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Units_ContractId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Units");

            migrationBuilder.AddColumn<string>(
                name: "ContractLink",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 687, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "MonthlyCost",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2021, 1, 12, 11, 52, 17, 690, DateTimeKind.Local).AddTicks(1943));
        }
    }
}
