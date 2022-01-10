using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eGertis.Migrations
{
    public partial class fixy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FinalOrders_FinalOrderId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "FinalOrders");

            migrationBuilder.RenameColumn(
                name: "FinalOrderId",
                table: "Orders",
                newName: "OrderRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_FinalOrderId",
                table: "Orders",
                newName: "IX_Orders_OrderRequestId");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinale",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "OrderRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SailCampId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRequests_SailCamps_SailCampId",
                        column: x => x.SailCampId,
                        principalTable: "SailCamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequests_SailCampId",
                table: "OrderRequests",
                column: "SailCampId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderRequests_OrderRequestId",
                table: "Orders",
                column: "OrderRequestId",
                principalTable: "OrderRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderRequests_OrderRequestId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderRequests");

            migrationBuilder.DropColumn(
                name: "IsFinale",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderRequestId",
                table: "Orders",
                newName: "FinalOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderRequestId",
                table: "Orders",
                newName: "IX_Orders_FinalOrderId");

            migrationBuilder.CreateTable(
                name: "FinalOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SailCampId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalOrders_SailCamps_SailCampId",
                        column: x => x.SailCampId,
                        principalTable: "SailCamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinalOrders_SailCampId",
                table: "FinalOrders",
                column: "SailCampId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FinalOrders_FinalOrderId",
                table: "Orders",
                column: "FinalOrderId",
                principalTable: "FinalOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
