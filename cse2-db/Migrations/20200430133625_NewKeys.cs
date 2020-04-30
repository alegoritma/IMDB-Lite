using Microsoft.EntityFrameworkCore.Migrations;

namespace cse2_db.Migrations
{
    public partial class NewKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TvEpisodeWriter_PersonId",
                table: "TvEpisodeWriter");

            migrationBuilder.DropIndex(
                name: "IX_TvEpisodeProducer_PersonId",
                table: "TvEpisodeProducer");

            migrationBuilder.DropIndex(
                name: "IX_TvEpisodeDirector_PersonId",
                table: "TvEpisodeDirector");

            migrationBuilder.DropIndex(
                name: "IX_TvEpisodeCastCharacter_CharacterId",
                table: "TvEpisodeCastCharacter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TvEpisodeWriter",
                table: "TvEpisodeWriter",
                columns: new[] { "PersonId", "TvEpisodeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TvEpisodeProducer",
                table: "TvEpisodeProducer",
                columns: new[] { "PersonId", "TvEpisodeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TvEpisodeDirector",
                table: "TvEpisodeDirector",
                columns: new[] { "PersonId", "TvEpisodeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TvEpisodeCastCharacter",
                table: "TvEpisodeCastCharacter",
                columns: new[] { "CharacterId", "TvEpisodeCastId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TvEpisodeWriter",
                table: "TvEpisodeWriter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TvEpisodeProducer",
                table: "TvEpisodeProducer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TvEpisodeDirector",
                table: "TvEpisodeDirector");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TvEpisodeCastCharacter",
                table: "TvEpisodeCastCharacter");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeWriter_PersonId",
                table: "TvEpisodeWriter",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeProducer_PersonId",
                table: "TvEpisodeProducer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeDirector_PersonId",
                table: "TvEpisodeDirector",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeCastCharacter_CharacterId",
                table: "TvEpisodeCastCharacter",
                column: "CharacterId");
        }
    }
}
