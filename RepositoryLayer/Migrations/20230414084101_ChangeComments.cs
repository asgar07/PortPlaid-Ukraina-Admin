using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class ChangeComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Order_OrderId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "BankCard",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCard",
                table: "Comments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReturnMethod",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReturnPrice",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Order_OrderId",
                table: "Comments",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Order_OrderId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BankCard",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsCard",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ReturnMethod",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ReturnPrice",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Order_OrderId",
                table: "Comments",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
