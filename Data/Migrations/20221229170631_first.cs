using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbumProject.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Singers",
                columns: table => new
                {
                    SingerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SingerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SingerLName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SingerNationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SingerAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singers", x => x.SingerId);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumSongCount = table.Column<int>(type: "int", nullable: false),
                    AlbumGenre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumScore = table.Column<int>(type: "int", nullable: false),
                    AlbumYear = table.Column<int>(type: "int", nullable: false),
                    SingerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_Albums_Singers_SingerId",
                        column: x => x.SingerId,
                        principalTable: "Singers",
                        principalColumn: "SingerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_SingerId",
                table: "Albums",
                column: "SingerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Singers");
        }
    }
}
