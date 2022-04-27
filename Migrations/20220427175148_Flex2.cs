using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eGertis.Migrations
{
    public partial class Flex2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderRequests_OrderRequestId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderComponents");

            migrationBuilder.DropTable(
                name: "OrderRequests");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderRequestId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderRequestId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "IsFinale",
                table: "Orders",
                newName: "IsRealized");

            migrationBuilder.RenameColumn(
                name: "BoatName",
                table: "Orders",
                newName: "Title");

            migrationBuilder.CreateTable(
                name: "ItemWrappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemWrappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemWrappers_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemWrappers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemWrappers_ItemId",
                table: "ItemWrappers",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemWrappers_OrderId",
                table: "ItemWrappers",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemWrappers");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Orders",
                newName: "BoatName");

            migrationBuilder.RenameColumn(
                name: "IsRealized",
                table: "Orders",
                newName: "IsFinale");

            migrationBuilder.AddColumn<int>(
                name: "OrderRequestId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderComponents_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderComponents_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderRequestId",
                table: "Orders",
                column: "OrderRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderComponents_ItemId",
                table: "OrderComponents",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderComponents_OrderId",
                table: "OrderComponents",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderRequests_OrderRequestId",
                table: "Orders",
                column: "OrderRequestId",
                principalTable: "OrderRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
