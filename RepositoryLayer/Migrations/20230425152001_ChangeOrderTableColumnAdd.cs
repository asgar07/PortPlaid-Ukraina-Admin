using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class ChangeOrderTableColumnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ManagerId",
                table: "Order",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_ManagerId",
                table: "Order",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_ManagerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ManagerId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Order");
        }
    }
}
