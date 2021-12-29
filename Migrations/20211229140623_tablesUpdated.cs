using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteApp.Migrations
{
    public partial class tablesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Categories",
                newName: "Participant");

            migrationBuilder.RenameColumn(
                name: "CategoryType",
                table: "Categories",
                newName: "Workout");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Workout",
                table: "Categories",
                newName: "CategoryType");

            migrationBuilder.RenameColumn(
                name: "Participant",
                table: "Categories",
                newName: "DisplayOrder");
        }
    }
}
