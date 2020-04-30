using Microsoft.EntityFrameworkCore.Migrations;

namespace cse2_db.Migrations
{
    public partial class WithPlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Season_TvSeries_TvSeriesId",
                table: "Season");

            migrationBuilder.AlterColumn<long>(
                name: "TvSeriesId",
                table: "Season",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TvSeriesPlatform_PlatformId",
                table: "TvSeriesPlatform",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeriesPlatform_TvSeriesId",
                table: "TvSeriesPlatform",
                column: "TvSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlatform_MovieId",
                table: "MoviePlatform",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlatform_PlatformId",
                table: "MoviePlatform",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePlatform_Movie_MovieId",
                table: "MoviePlatform",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePlatform_Platform_PlatformId",
                table: "MoviePlatform",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Season_TvSeries_TvSeriesId",
                table: "Season",
                column: "TvSeriesId",
                principalTable: "TvSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TvSeriesPlatform_Platform_PlatformId",
                table: "TvSeriesPlatform",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TvSeriesPlatform_TvSeries_TvSeriesId",
                table: "TvSeriesPlatform",
                column: "TvSeriesId",
                principalTable: "TvSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePlatform_Movie_MovieId",
                table: "MoviePlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviePlatform_Platform_PlatformId",
                table: "MoviePlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_TvSeries_TvSeriesId",
                table: "Season");

            migrationBuilder.DropForeignKey(
                name: "FK_TvSeriesPlatform_Platform_PlatformId",
                table: "TvSeriesPlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_TvSeriesPlatform_TvSeries_TvSeriesId",
                table: "TvSeriesPlatform");

            migrationBuilder.DropIndex(
                name: "IX_TvSeriesPlatform_PlatformId",
                table: "TvSeriesPlatform");

            migrationBuilder.DropIndex(
                name: "IX_TvSeriesPlatform_TvSeriesId",
                table: "TvSeriesPlatform");

            migrationBuilder.DropIndex(
                name: "IX_MoviePlatform_MovieId",
                table: "MoviePlatform");

            migrationBuilder.DropIndex(
                name: "IX_MoviePlatform_PlatformId",
                table: "MoviePlatform");

            migrationBuilder.AlterColumn<long>(
                name: "TvSeriesId",
                table: "Season",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Season_TvSeries_TvSeriesId",
                table: "Season",
                column: "TvSeriesId",
                principalTable: "TvSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
