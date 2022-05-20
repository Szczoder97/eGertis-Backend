using Microsoft.EntityFrameworkCore.Migrations;

namespace eGertis.Migrations
{
    public partial class SepareteItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemWrappers_Items_ItemId",
                table: "ItemWrappers");

            migrationBuilder.DropIndex(
                name: "IX_ItemWrappers_ItemId",
                table: "ItemWrappers");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemWrappers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ItemWrappers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ItemWrappers");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemWrappers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemWrappers_ItemId",
                table: "ItemWrappers",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemWrappers_Items_ItemId",
                table: "ItemWrappers",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
