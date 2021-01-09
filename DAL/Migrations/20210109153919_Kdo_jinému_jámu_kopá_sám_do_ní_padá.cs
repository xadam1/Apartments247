using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Kdo_jinému_jámu_kopá_sám_do_ní_padá : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[] { 17, "Stockholm", "6a", "Švédsko", "Brigádnická", "548 02" });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 11, "Workout hřiště" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5,
                column: "UnitGroupId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7,
                column: "UnitGroupId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8,
                column: "UnitGroupId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9,
                column: "UnitGroupId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 17, 17, 5, "Workout hřiště Hroch", "Hřiště pro posilování a řeka pro otužování" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractLink", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 12, null, 50, 51, 17, 1, 11 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5,
                column: "UnitGroupId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7,
                column: "UnitGroupId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8,
                column: "UnitGroupId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9,
                column: "UnitGroupId",
                value: 1);
        }
    }
}
