using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackLibraryWH40K.Store.Migrations.SqlServerMigrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "World",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_World", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Primarch",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    HomeWorldId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Primarch", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Primarch_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Primarch_World_HomeWorldId",
                        column: x => x.HomeWorldId,
                        principalTable: "World",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Legion",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimarchNumber = table.Column<int>(type: "int", nullable: true),
                    ChapterMasterId = table.Column<int>(type: "int", nullable: true),
                    HomeWorldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legion", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Legion_Person_ChapterMasterId",
                        column: x => x.ChapterMasterId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Legion_Primarch_PrimarchNumber",
                        column: x => x.PrimarchNumber,
                        principalTable: "Primarch",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Legion_World_HomeWorldId",
                        column: x => x.HomeWorldId,
                        principalTable: "World",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warcry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChapterMasterId = table.Column<int>(type: "int", nullable: true),
                    LegionNumber = table.Column<int>(type: "int", nullable: true),
                    HomeWorldId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChapterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapter_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chapter_Legion_LegionNumber",
                        column: x => x.LegionNumber,
                        principalTable: "Legion",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chapter_Person_ChapterMasterId",
                        column: x => x.ChapterMasterId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chapter_World_HomeWorldId",
                        column: x => x.HomeWorldId,
                        principalTable: "World",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_ChapterId",
                table: "Chapter",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_ChapterMasterId",
                table: "Chapter",
                column: "ChapterMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_HomeWorldId",
                table: "Chapter",
                column: "HomeWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_LegionNumber",
                table: "Chapter",
                column: "LegionNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Legion_ChapterMasterId",
                table: "Legion",
                column: "ChapterMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Legion_HomeWorldId",
                table: "Legion",
                column: "HomeWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_Legion_PrimarchNumber",
                table: "Legion",
                column: "PrimarchNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_StateId",
                table: "Organization",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_OrganizationId",
                table: "Person",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Primarch_HomeWorldId",
                table: "Primarch",
                column: "HomeWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_Primarch_StateId",
                table: "Primarch",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "Legion");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Primarch");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "World");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
