using Microsoft.EntityFrameworkCore.Migrations;

namespace stars.database.Migrations
{
    public partial class StarsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bulding",
                table: "Users",
                newName: "ReqFleet");

            migrationBuilder.AddColumn<int>(
                name: "Building",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReqBuild",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Building",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReqBuild",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ReqFleet",
                table: "Users",
                newName: "Bulding");
        }
    }
}
