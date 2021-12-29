using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteApp.Migrations
{
    public partial class addmigrationsecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteBody",
                table: "Notes",
                newName: "NoteText");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "NoteText",
                table: "Notes",
                newName: "NoteBody");
        }
    }
}
