using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class NoteLabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LableEntityLableID",
                table: "Notes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NoteLabelEntity",
                columns: table => new
                {
                    LabelNoteID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelID = table.Column<long>(type: "bigint", nullable: false),
                    NoteID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteLabelEntity", x => x.LabelNoteID);
                    table.ForeignKey(
                        name: "FK_NoteLabelEntity_Lables_LabelID",
                        column: x => x.LabelID,
                        principalTable: "Lables",
                        principalColumn: "LableID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteLabelEntity_Notes_NoteID",
                        column: x => x.NoteID,
                        principalTable: "Notes",
                        principalColumn: "NoteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LableEntityLableID",
                table: "Notes",
                column: "LableEntityLableID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteLabelEntity_LabelID",
                table: "NoteLabelEntity",
                column: "LabelID");

            migrationBuilder.CreateIndex(
                name: "IX_NoteLabelEntity_NoteID",
                table: "NoteLabelEntity",
                column: "NoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Lables_LableEntityLableID",
                table: "Notes",
                column: "LableEntityLableID",
                principalTable: "Lables",
                principalColumn: "LableID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Lables_LableEntityLableID",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "NoteLabelEntity");

            migrationBuilder.DropIndex(
                name: "IX_Notes_LableEntityLableID",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LableEntityLableID",
                table: "Notes");
        }
    }
}
