using Microsoft.EntityFrameworkCore.Migrations;

namespace eGertis.Migrations
{
    public partial class Refresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRequests_SailCamps_SailCampId",
                table: "OrderRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_SailCamps_SailCampId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "SailCamps");

            migrationBuilder.DropIndex(
                name: "IX_Users_SailCampId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_OrderRequests_SailCampId",
                table: "OrderRequests");

            migrationBuilder.DropColumn(
                name: "SailCampId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SailCampId",
                table: "OrderRequests");

            migrationBuilder.AddColumn<string>(
                name: "BoatName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoatName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderRequests");

            migrationBuilder.AddColumn<int>(
                name: "SailCampId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SailCampId",
                table: "OrderRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SailCamps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SailCamps", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SailCampId",
                table: "Users",
                column: "SailCampId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequests_SailCampId",
                table: "OrderRequests",
                column: "SailCampId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRequests_SailCamps_SailCampId",
                table: "OrderRequests",
                column: "SailCampId",
                principalTable: "SailCamps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SailCamps_SailCampId",
                table: "Users",
                column: "SailCampId",
                principalTable: "SailCamps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
