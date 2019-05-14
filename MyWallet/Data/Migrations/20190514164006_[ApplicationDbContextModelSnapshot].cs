using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWallet.Data.Migrations
{
    public partial class ApplicationDbContextModelSnapshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "ItemName");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Costs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Costs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Costs");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "Items",
                newName: "Name");
        }
    }
}
