using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Migrations
{
    public partial class RemoveUnnecessaryColumnInOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderItem",
                nullable: false,
                defaultValue: 0);
        }
    }
}
