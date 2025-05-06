using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtMusic.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_songpackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "PackageSong",
                columns: table => new
                {
                    PackagesPackageId = table.Column<int>(type: "int", nullable: false),
                    SongsSongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageSong", x => new { x.PackagesPackageId, x.SongsSongId });
                    table.ForeignKey(
                        name: "FK_PackageSong_Packages_PackagesPackageId",
                        column: x => x.PackagesPackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageSong_Songs_SongsSongId",
                        column: x => x.SongsSongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PackageId",
                table: "AspNetUsers",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageSong_SongsSongId",
                table: "PackageSong",
                column: "SongsSongId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Packages_PackageId",
                table: "AspNetUsers",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Packages_PackageId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PackageSong");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PackageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "AspNetUsers");
        }
    }
}
