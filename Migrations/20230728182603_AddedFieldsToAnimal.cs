using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReptileAPI.Migrations
{
    public partial class AddedFieldsToAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Species",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bedding_Change",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Feeding_Schedule",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feeding_Size",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Morphs",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Water_Change",
                table: "Animals",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bedding_Change",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Feeding_Schedule",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Feeding_Size",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Morphs",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Water_Change",
                table: "Animals");

            migrationBuilder.AlterColumn<string>(
                name: "Species",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
