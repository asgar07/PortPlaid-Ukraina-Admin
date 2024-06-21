using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class AddTableManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerStartStopId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ManagerStartStop",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerStartStop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagerStartStop_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ManagerStartStopId",
                table: "Order",
                column: "ManagerStartStopId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerStartStop_AppUserId",
                table: "ManagerStartStop",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ManagerStartStop_ManagerStartStopId",
                table: "Order",
                column: "ManagerStartStopId",
                principalTable: "ManagerStartStop",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_ManagerStartStop_ManagerStartStopId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "ManagerStartStop");

            migrationBuilder.DropIndex(
                name: "IX_Order_ManagerStartStopId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ManagerStartStopId",
                table: "Order");
        }
    }
}
