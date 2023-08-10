using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReptileAPI.Migrations
{
    public partial class AddedMorphTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Morphs",
                table: "Animals");

            migrationBuilder.CreateTable(
                name: "Morphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Morphs_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Morphs_AnimalId",
                table: "Morphs",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Morphs");

            migrationBuilder.AddColumn<string>(
                name: "Morphs",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
