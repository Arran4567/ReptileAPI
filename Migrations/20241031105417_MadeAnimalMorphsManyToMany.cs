using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReptileAPI.Migrations
{
    public partial class MadeAnimalMorphsManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Morphs_Animals_AnimalId",
                table: "Morphs");

            migrationBuilder.DropIndex(
                name: "IX_Morphs_AnimalId",
                table: "Morphs");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Morphs");

            migrationBuilder.CreateTable(
                name: "AnimalMorph",
                columns: table => new
                {
                    AnimalsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MorphsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalMorph", x => new { x.AnimalsId, x.MorphsId });
                    table.ForeignKey(
                        name: "FK_AnimalMorph_Animals_AnimalsId",
                        column: x => x.AnimalsId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalMorph_Morphs_MorphsId",
                        column: x => x.MorphsId,
                        principalTable: "Morphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalMorph_MorphsId",
                table: "AnimalMorph",
                column: "MorphsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalMorph");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimalId",
                table: "Morphs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Morphs_AnimalId",
                table: "Morphs",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Morphs_Animals_AnimalId",
                table: "Morphs",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id");
        }
    }
}
