using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace cse2_db.Migrations
{
    public partial class PlatformBindings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePlatform_Platform_PlatformId",
                table: "MoviePlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_TvSeriesPlatform_Platform_PlatformId",
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

            migrationBuilder.AddColumn<long>(
                name: "PlatformId1",
                table: "TvSeriesPlatform",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Platform",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "PlatformId1",
                table: "MoviePlatform",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TvSeriesPlatform",
                table: "TvSeriesPlatform",
                columns: new[] { "TvSeriesId", "PlatformId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviePlatform",
                table: "MoviePlatform",
                columns: new[] { "MovieId", "PlatformId" });

            migrationBuilder.CreateIndex(
                name: "IX_TvSeriesPlatform_PlatformId1",
                table: "TvSeriesPlatform",
                column: "PlatformId1");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlatform_PlatformId1",
                table: "MoviePlatform",
                column: "PlatformId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePlatform_Platform_PlatformId1",
                table: "MoviePlatform",
                column: "PlatformId1",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TvSeriesPlatform_Platform_PlatformId1",
                table: "TvSeriesPlatform",
                column: "PlatformId1",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePlatform_Platform_PlatformId1",
                table: "MoviePlatform");

            migrationBuilder.DropForeignKey(
                name: "FK_TvSeriesPlatform_Platform_PlatformId1",
                table: "TvSeriesPlatform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TvSeriesPlatform",
                table: "TvSeriesPlatform");

            migrationBuilder.DropIndex(
                name: "IX_TvSeriesPlatform_PlatformId1",
                table: "TvSeriesPlatform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviePlatform",
                table: "MoviePlatform");

            migrationBuilder.DropIndex(
                name: "IX_MoviePlatform_PlatformId1",
                table: "MoviePlatform");

            migrationBuilder.DropColumn(
                name: "PlatformId1",
                table: "TvSeriesPlatform");

            migrationBuilder.DropColumn(
                name: "PlatformId1",
                table: "MoviePlatform");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Platform",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                name: "FK_MoviePlatform_Platform_PlatformId",
                table: "MoviePlatform",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TvSeriesPlatform_Platform_PlatformId",
                table: "TvSeriesPlatform",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
