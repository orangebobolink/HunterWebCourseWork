using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class MessangerIdupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Messangers_MessangerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MessangerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MessangerId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessangerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MessangerId",
                table: "Orders",
                column: "MessangerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Messangers_MessangerId",
                table: "Orders",
                column: "MessangerId",
                principalTable: "Messangers",
                principalColumn: "Id");
        }
    }
}
