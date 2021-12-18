using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaBase.DAL.Migrations
{
    public partial class foreignkeys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollectionID",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionID",
                table: "Users",
                type: "int",
                nullable: true);
        }
    }
}
