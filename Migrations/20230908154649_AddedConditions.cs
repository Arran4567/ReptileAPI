using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReptileAPI.Migrations
{
    public partial class AddedConditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConditionId",
                table: "Species",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotSpotTemp = table.Column<double>(type: "float", nullable: false),
                    AmbientTemp = table.Column<double>(type: "float", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Species_ConditionId",
                table: "Species",
                column: "ConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Conditions_ConditionId",
                table: "Species",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Species_Conditions_ConditionId",
                table: "Species");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropIndex(
                name: "IX_Species_ConditionId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "Species");
        }
    }
}
