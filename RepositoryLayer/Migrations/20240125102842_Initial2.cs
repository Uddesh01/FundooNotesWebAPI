using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lables_Users_UserId",
                table: "Lables");

            migrationBuilder.DropIndex(
                name: "IX_Lables_UserId",
                table: "Lables");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Lables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lables_UserId",
                table: "Lables",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lables_Users_UserId",
                table: "Lables",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
