using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Migrations
{
    public partial class FixOrderItemTableColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderItem");
        }
    }
}
