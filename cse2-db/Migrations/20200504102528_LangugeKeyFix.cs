using Microsoft.EntityFrameworkCore.Migrations;

namespace cse2_db.Migrations
{
    public partial class LangugeKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TvEpisodeLanguage_TvEpisodeId",
                table: "TvEpisodeLanguage");

            migrationBuilder.DropIndex(
                name: "IX_MovieLanguage_MovieId",
                table: "MovieLanguage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TvEpisodeLanguage",
                table: "TvEpisodeLanguage",
                columns: new[] { "TvEpisodeId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieLanguage",
                table: "MovieLanguage",
                columns: new[] { "MovieId", "LanguageId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TvEpisodeLanguage",
                table: "TvEpisodeLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieLanguage",
                table: "MovieLanguage");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeLanguage_TvEpisodeId",
                table: "TvEpisodeLanguage",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguage_MovieId",
                table: "MovieLanguage",
                column: "MovieId");
        }
    }
}
