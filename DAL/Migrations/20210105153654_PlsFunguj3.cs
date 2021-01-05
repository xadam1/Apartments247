using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class PlsFunguj3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitUnitGroup");

            migrationBuilder.AddColumn<int>(
                name: "UnitGroupId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitGroupId",
                table: "Units",
                column: "UnitGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitGroups_UnitGroupId",
                table: "Units",
                column: "UnitGroupId",
                principalTable: "UnitGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitGroups_UnitGroupId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_UnitGroupId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitGroupId",
                table: "Units");

            migrationBuilder.CreateTable(
                name: "UnitUnitGroup",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UnitGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitUnitGroup", x => new { x.UnitId, x.UnitGroupId });
                    table.ForeignKey(
                        name: "FK_UnitUnitGroup_UnitGroups_UnitGroupId",
                        column: x => x.UnitGroupId,
                        principalTable: "UnitGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitUnitGroup_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitUnitGroup_UnitGroupId",
                table: "UnitUnitGroup",
                column: "UnitGroupId");
        }
    }
}
