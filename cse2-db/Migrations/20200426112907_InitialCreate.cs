using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace cse2_db.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentRating",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageUrl = table.Column<string>(maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeyWord",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyWord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviePlatform",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    PlatformId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Url = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvSeriesPlatform",
                columns: table => new
                {
                    TvSeriesId = table.Column<long>(nullable: false),
                    PlatformId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(maxLength: 300, nullable: true),
                    StoryLine = table.Column<string>(maxLength: 2000, nullable: true),
                    AirDate = table.Column<DateTime>(nullable: true),
                    ImageId = table.Column<long>(nullable: true),
                    ContentRatingId = table.Column<short>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    AvgRating = table.Column<float>(nullable: false),
                    VotesCount = table.Column<long>(nullable: false),
                    ImdbId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_ContentRating_ContentRatingId",
                        column: x => x.ContentRatingId,
                        principalTable: "ContentRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movie_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    DeathDate = table.Column<DateTime>(nullable: true),
                    ImageId = table.Column<long>(nullable: true),
                    ImdbId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(maxLength: 300, nullable: true),
                    StoryLine = table.Column<string>(maxLength: 2000, nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    ImageId = table.Column<long>(nullable: true),
                    Duration = table.Column<int>(nullable: true),
                    ContentRatingId = table.Column<short>(nullable: true),
                    AvgRating = table.Column<float>(nullable: false),
                    VotesCount = table.Column<long>(nullable: false),
                    ImdbId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvSeries_ContentRating_ContentRatingId",
                        column: x => x.ContentRatingId,
                        principalTable: "ContentRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TvSeries_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieCompany",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    CompanyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MovieCompany_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCompany_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCountry",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    CountryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MovieCountry_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCountry_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    GenreId = table.Column<long>(nullable: false),
                    MovieId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieKeyWord",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    KeyWordId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MovieKeyWord_KeyWord_KeyWordId",
                        column: x => x.KeyWordId,
                        principalTable: "KeyWord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieKeyWord_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLanguage",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MovieLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLanguage_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLocation",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MovieLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLocation_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCast",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieId = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false),
                    Importance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieCast_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCast_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirector",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MovieDirector_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirector_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieProducer",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MovieProducer_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieProducer_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieWriter",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MovieWriter_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieWriter_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeasonNumber = table.Column<int>(nullable: false),
                    TvSeriesId = table.Column<long>(nullable: true),
                    TVSeriesImdbId = table.Column<string>(maxLength: 50, nullable: true),
                    ImdbId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Season_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TvSeriesKeyWord",
                columns: table => new
                {
                    TvSeriesId = table.Column<long>(nullable: false),
                    KeyWordId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvSeriesKeyWord_KeyWord_KeyWordId",
                        column: x => x.KeyWordId,
                        principalTable: "KeyWord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSeriesKeyWord_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCastCharacter",
                columns: table => new
                {
                    MovieCastId = table.Column<long>(nullable: false),
                    CharacterId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MovieCastCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCastCharacter_MovieCast_MovieCastId",
                        column: x => x.MovieCastId,
                        principalTable: "MovieCast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisode",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    StoryLine = table.Column<string>(maxLength: 2000, nullable: true),
                    EpisodeNumber = table.Column<int>(nullable: false),
                    SeasonId = table.Column<long>(nullable: false),
                    AirDate = table.Column<DateTime>(nullable: true),
                    ImageId = table.Column<long>(nullable: true),
                    Duration = table.Column<int>(nullable: true),
                    AvgRating = table.Column<float>(nullable: false),
                    VotesCount = table.Column<long>(nullable: false),
                    ImdbId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvEpisode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvEpisode_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TvEpisode_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeCast",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TvEpisodeId = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false),
                    Importance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvEpisodeCast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvEpisodeCast_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeCast_TvEpisode_TvEpisodeId",
                        column: x => x.TvEpisodeId,
                        principalTable: "TvEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeCompany",
                columns: table => new
                {
                    TvEpisodeId = table.Column<long>(nullable: false),
                    CompanyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvEpisodeCompany_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeCompany_TvEpisode_TvEpisodeId",
                        column: x => x.TvEpisodeId,
                        principalTable: "TvEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeCountry",
                columns: table => new
                {
                    TvEpisodeId = table.Column<long>(nullable: false),
                    CountryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvEpisodeCountry_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeCountry_TvEpisode_TvEpisodeId",
                        column: x => x.TvEpisodeId,
                        principalTable: "TvEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeDirector",
                columns: table => new
                {
                    TvEpisodeId = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvEpisodeDirector_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeDirector_TvEpisode_TvEpisodeId",
                        column: x => x.TvEpisodeId,
                        principalTable: "TvEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeGenre",
                columns: table => new
                {
                    TvEpisodeId = table.Column<long>(nullable: false),
                    GenreId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvEpisodeGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeGenre_TvEpisode_TvEpisodeId",
                        column: x => x.TvEpisodeId,
                        principalTable: "TvEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeKeyWord",
                columns: table => new
                {
                    TvEpisodeId = table.Column<long>(nullable: false),
                    KeyWordId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvEpisodeKeyWord_KeyWord_KeyWordId",
                        column: x => x.KeyWordId,
                        principalTable: "KeyWord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeKeyWord_TvEpisode_TvEpisodeId",
                        column: x => x.TvEpisodeId,
                        principalTable: "TvEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeLanguage",
                columns: table => new
                {
                    TvEpisodeId = table.Column<long>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvEpisodeLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeLanguage_TvEpisode_TvEpisodeId",
                        column: x => x.TvEpisodeId,
                        principalTable: "TvEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeLocation",
                columns: table => new
                {
                    TvEpisodeId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvEpisodeLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeLocation_TvEpisode_TvEpisodeId",
                        column: x => x.TvEpisodeId,
                        principalTable: "TvEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeProducer",
                columns: table => new
                {
                    TvEpisodeId = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvEpisodeProducer_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeProducer_TvEpisode_TvEpisodeId",
                        column: x => x.TvEpisodeId,
                        principalTable: "TvEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeWriter",
                columns: table => new
                {
                    TvEpisodeId = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvEpisodeWriter_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeWriter_TvEpisode_TvEpisodeId",
                        column: x => x.TvEpisodeId,
                        principalTable: "TvEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvEpisodeCastCharacter",
                columns: table => new
                {
                    TvEpisodeCastId = table.Column<long>(nullable: false),
                    CharacterId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TvEpisodeCastCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvEpisodeCastCharacter_TvEpisodeCast_TvEpisodeCastId",
                        column: x => x.TvEpisodeCastId,
                        principalTable: "TvEpisodeCast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_Name",
                table: "Character",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Name",
                table: "Company",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ContentRating_Name",
                table: "ContentRating",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Name",
                table: "Genre",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_KeyWord_Name",
                table: "KeyWord",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Language_Name",
                table: "Language",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Name",
                table: "Location",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_AirDate",
                table: "Movie",
                column: "AirDate");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_AvgRating",
                table: "Movie",
                column: "AvgRating");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ContentRatingId",
                table: "Movie",
                column: "ContentRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Duration",
                table: "Movie",
                column: "Duration");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ImageId",
                table: "Movie",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ImdbId",
                table: "Movie",
                column: "ImdbId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Title",
                table: "Movie",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_VotesCount",
                table: "Movie",
                column: "VotesCount");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_Importance",
                table: "MovieCast",
                column: "Importance");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_MovieId",
                table: "MovieCast",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_PersonId",
                table: "MovieCast",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCastCharacter_CharacterId",
                table: "MovieCastCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCastCharacter_MovieCastId",
                table: "MovieCastCharacter",
                column: "MovieCastId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCompany_CompanyId",
                table: "MovieCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCompany_MovieId",
                table: "MovieCompany",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCountry_CountryId",
                table: "MovieCountry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCountry_MovieId",
                table: "MovieCountry",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirector_MovieId",
                table: "MovieDirector",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirector_PersonId",
                table: "MovieDirector",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MovieId",
                table: "MovieGenre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieKeyWord_KeyWordId",
                table: "MovieKeyWord",
                column: "KeyWordId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieKeyWord_MovieId",
                table: "MovieKeyWord",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguage_LanguageId",
                table: "MovieLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguage_MovieId",
                table: "MovieLanguage",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLocation_LocationId",
                table: "MovieLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLocation_MovieId",
                table: "MovieLocation",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProducer_MovieId",
                table: "MovieProducer",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProducer_PersonId",
                table: "MovieProducer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieWriter_MovieId",
                table: "MovieWriter",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieWriter_PersonId",
                table: "MovieWriter",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_BirthDate",
                table: "Person",
                column: "BirthDate");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DeathDate",
                table: "Person",
                column: "DeathDate");

            migrationBuilder.CreateIndex(
                name: "IX_Person_FullName",
                table: "Person",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ImageId",
                table: "Person",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ImdbId",
                table: "Person",
                column: "ImdbId");

            migrationBuilder.CreateIndex(
                name: "IX_Platform_Name",
                table: "Platform",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Season_ImdbId",
                table: "Season",
                column: "ImdbId");

            migrationBuilder.CreateIndex(
                name: "IX_Season_SeasonNumber",
                table: "Season",
                column: "SeasonNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Season_TVSeriesImdbId",
                table: "Season",
                column: "TVSeriesImdbId");

            migrationBuilder.CreateIndex(
                name: "IX_Season_TvSeriesId",
                table: "Season",
                column: "TvSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisode_AirDate",
                table: "TvEpisode",
                column: "AirDate");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisode_AvgRating",
                table: "TvEpisode",
                column: "AvgRating");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisode_Duration",
                table: "TvEpisode",
                column: "Duration");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisode_EpisodeNumber",
                table: "TvEpisode",
                column: "EpisodeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisode_ImageId",
                table: "TvEpisode",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisode_ImdbId",
                table: "TvEpisode",
                column: "ImdbId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisode_SeasonId",
                table: "TvEpisode",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisode_Title",
                table: "TvEpisode",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisode_VotesCount",
                table: "TvEpisode",
                column: "VotesCount");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeCast_Importance",
                table: "TvEpisodeCast",
                column: "Importance");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeCast_PersonId",
                table: "TvEpisodeCast",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeCast_TvEpisodeId",
                table: "TvEpisodeCast",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeCastCharacter_CharacterId",
                table: "TvEpisodeCastCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeCastCharacter_TvEpisodeCastId",
                table: "TvEpisodeCastCharacter",
                column: "TvEpisodeCastId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeCompany_CompanyId",
                table: "TvEpisodeCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeCompany_TvEpisodeId",
                table: "TvEpisodeCompany",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeCountry_CountryId",
                table: "TvEpisodeCountry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeCountry_TvEpisodeId",
                table: "TvEpisodeCountry",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeDirector_PersonId",
                table: "TvEpisodeDirector",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeDirector_TvEpisodeId",
                table: "TvEpisodeDirector",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeGenre_GenreId",
                table: "TvEpisodeGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeGenre_TvEpisodeId",
                table: "TvEpisodeGenre",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeKeyWord_KeyWordId",
                table: "TvEpisodeKeyWord",
                column: "KeyWordId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeKeyWord_TvEpisodeId",
                table: "TvEpisodeKeyWord",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeLanguage_LanguageId",
                table: "TvEpisodeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeLanguage_TvEpisodeId",
                table: "TvEpisodeLanguage",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeLocation_LocationId",
                table: "TvEpisodeLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeLocation_TvEpisodeId",
                table: "TvEpisodeLocation",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeProducer_PersonId",
                table: "TvEpisodeProducer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeProducer_TvEpisodeId",
                table: "TvEpisodeProducer",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeWriter_PersonId",
                table: "TvEpisodeWriter",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodeWriter_TvEpisodeId",
                table: "TvEpisodeWriter",
                column: "TvEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_AvgRating",
                table: "TvSeries",
                column: "AvgRating");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_ContentRatingId",
                table: "TvSeries",
                column: "ContentRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_Duration",
                table: "TvSeries",
                column: "Duration");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_ImageId",
                table: "TvSeries",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_ImdbId",
                table: "TvSeries",
                column: "ImdbId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_Title",
                table: "TvSeries",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_VotesCount",
                table: "TvSeries",
                column: "VotesCount");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeriesKeyWord_KeyWordId",
                table: "TvSeriesKeyWord",
                column: "KeyWordId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeriesKeyWord_TvSeriesId",
                table: "TvSeriesKeyWord",
                column: "TvSeriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCastCharacter");

            migrationBuilder.DropTable(
                name: "MovieCompany");

            migrationBuilder.DropTable(
                name: "MovieCountry");

            migrationBuilder.DropTable(
                name: "MovieDirector");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "MovieKeyWord");

            migrationBuilder.DropTable(
                name: "MovieLanguage");

            migrationBuilder.DropTable(
                name: "MovieLocation");

            migrationBuilder.DropTable(
                name: "MoviePlatform");

            migrationBuilder.DropTable(
                name: "MovieProducer");

            migrationBuilder.DropTable(
                name: "MovieWriter");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropTable(
                name: "TvEpisodeCastCharacter");

            migrationBuilder.DropTable(
                name: "TvEpisodeCompany");

            migrationBuilder.DropTable(
                name: "TvEpisodeCountry");

            migrationBuilder.DropTable(
                name: "TvEpisodeDirector");

            migrationBuilder.DropTable(
                name: "TvEpisodeGenre");

            migrationBuilder.DropTable(
                name: "TvEpisodeKeyWord");

            migrationBuilder.DropTable(
                name: "TvEpisodeLanguage");

            migrationBuilder.DropTable(
                name: "TvEpisodeLocation");

            migrationBuilder.DropTable(
                name: "TvEpisodeProducer");

            migrationBuilder.DropTable(
                name: "TvEpisodeWriter");

            migrationBuilder.DropTable(
                name: "TvSeriesKeyWord");

            migrationBuilder.DropTable(
                name: "TvSeriesPlatform");

            migrationBuilder.DropTable(
                name: "MovieCast");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "TvEpisodeCast");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "KeyWord");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "TvEpisode");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "TvSeries");

            migrationBuilder.DropTable(
                name: "ContentRating");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
