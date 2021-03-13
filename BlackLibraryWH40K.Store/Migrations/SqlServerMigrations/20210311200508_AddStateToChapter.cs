using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackLibraryWH40K.Store.Migrations.SqlServerMigrations
{
    public partial class AddStateToChapter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Chapter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_StateId",
                table: "Chapter",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_State_StateId",
                table: "Chapter",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_State_StateId",
                table: "Chapter");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_StateId",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Chapter");
        }
    }
}
