using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class ChangeOrderTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_appUserId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_appUserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "appUserId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPhoneNumber",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSurname",
                table: "Order",
                type: "nvarchar(max)",
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

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserPhoneNumber",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserSurname",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "appUserId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Order_appUserId",
                table: "Order",
                column: "appUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_appUserId",
                table: "Order",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
