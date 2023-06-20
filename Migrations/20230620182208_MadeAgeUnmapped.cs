using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReptileAPI.Migrations
{
    public partial class MadeAgeUnmapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Animals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
