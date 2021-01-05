using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ManytomanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Units_UnitId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Specifications_Address_AddressId",
                table: "Specifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitGroups_Specifications_SpecificationId",
                table: "UnitGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitGroups_Users_UserId",
                table: "UnitGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Specifications_SpecificationId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitGroups_UnitGroupId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitTypes_UnitTypeId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Units_UnitGroupId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_UnitGroups_SpecificationId",
                table: "UnitGroups");

            migrationBuilder.DropIndex(
                name: "IX_Specifications_AddressId",
                table: "Specifications");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_UnitId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "UnitGroupId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Equipment");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Equipment",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

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
                name: "IX_UnitGroups_SpecificationId",
                table: "UnitGroups",
                column: "SpecificationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_AddressId",
                table: "Specifications",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitEquipment_UnitsId",
                table: "UnitEquipment",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitUnitGroup_UnitGroupId",
                table: "UnitUnitGroup",
                column: "UnitGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specifications_Address_AddressId",
                table: "Specifications",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitGroups_Specifications_SpecificationId",
                table: "UnitGroups",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitGroups_Users_UserId",
                table: "UnitGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Specifications_SpecificationId",
                table: "Units",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitTypes_UnitTypeId",
                table: "Units",
                column: "UnitTypeId",
                principalTable: "UnitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specifications_Address_AddressId",
                table: "Specifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitGroups_Specifications_SpecificationId",
                table: "UnitGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitGroups_Users_UserId",
                table: "UnitGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Specifications_SpecificationId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitTypes_UnitTypeId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "UnitEquipment");

            migrationBuilder.DropTable(
                name: "UnitUnitGroup");

            migrationBuilder.DropIndex(
                name: "IX_UnitGroups_SpecificationId",
                table: "UnitGroups");

            migrationBuilder.DropIndex(
                name: "IX_Specifications_AddressId",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Equipment");

            migrationBuilder.AddColumn<int>(
                name: "UnitGroupId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentTypes_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitGroupId",
                table: "Units",
                column: "UnitGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitGroups_SpecificationId",
                table: "UnitGroups",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_AddressId",
                table: "Specifications",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_UnitId",
                table: "Equipment",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTypes_EquipmentId",
                table: "EquipmentTypes",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Units_UnitId",
                table: "Equipment",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specifications_Address_AddressId",
                table: "Specifications",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitGroups_Specifications_SpecificationId",
                table: "UnitGroups",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitGroups_Users_UserId",
                table: "UnitGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Specifications_SpecificationId",
                table: "Units",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitGroups_UnitGroupId",
                table: "Units",
                column: "UnitGroupId",
                principalTable: "UnitGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitTypes_UnitTypeId",
                table: "Units",
                column: "UnitTypeId",
                principalTable: "UnitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
