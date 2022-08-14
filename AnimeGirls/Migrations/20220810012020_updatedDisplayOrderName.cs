using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeGirls.Migrations
{
    public partial class updatedDisplayOrderName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiplayOrder",
                table: "Category",
                newName: "DisplayOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Category",
                newName: "DiplayOrder");
        }
    }
}
