using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Tak_dlouho_se_chodí_se_džbánem_pro_vodu_až_se_ucho_utrhne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Number", "State", "Street", "Zip" },
                values: new object[,]
                {
                    { 14, "Kodaň", "18b", "Dánsko", "Celní", "58 96" },
                    { 15, "Hora sv. Michala", "-", "Francie", "-", "-" },
                    { 16, "-", "-", "San Francisko", "-", "-" }
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 9, "Hrad na ostrově" },
                    { 10, "Vojenská věznice" }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 14, 14, 2, "Dědictví po prastrýci", "Dědictví od zapomenutého prastrýce, jenž emigroval do USA" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 15, 15, 3, "Hrad Le Mont Saint Michel", "80 metrů vysoký přílivový ostrov" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "AddressId", "ColorId", "Name", "Note" },
                values: new object[] { 16, 16, 4, "Pevnost Alcatraz", "Bývalá vojenská věznice, nyní historická památka" });

            migrationBuilder.InsertData(
                table: "UnitGroups",
                columns: new[] { "Id", "SpecificationId", "UserId" },
                values: new object[] { 5, 14, 1 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractLink", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 10, null, 0, 150, 15, 5, 9 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "ContractLink", "CurrentCapacity", "MaxCapacity", "SpecificationId", "UnitGroupId", "UnitTypeId" },
                values: new object[] { 11, null, 18, 23, 16, 5, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UnitGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
