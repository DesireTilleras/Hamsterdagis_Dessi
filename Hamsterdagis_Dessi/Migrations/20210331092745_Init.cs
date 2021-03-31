using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hamsterdagis_Dessi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountInArea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender_Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cage_Buddies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountOfBuddies = table.Column<int>(type: "int", nullable: false),
                    CageId = table.Column<int>(type: "int", nullable: true),
                    GenderInCageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cage_Buddies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cage_Buddies_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cage_Buddies_Genders_GenderInCageId",
                        column: x => x.GenderInCageId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hamsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hamster_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeForLastExercise = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: true),
                    Cage_BuddiesId = table.Column<int>(type: "int", nullable: true),
                    ExerciseAreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hamsters_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_Cage_Buddies_Cage_BuddiesId",
                        column: x => x.Cage_BuddiesId,
                        principalTable: "Cage_Buddies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_ExerciseAreas_ExerciseAreaId",
                        column: x => x.ExerciseAreaId,
                        principalTable: "ExerciseAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logg_Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: true),
                    HamsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logg_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logg_Activities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Logg_Activities_Hamsters_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "Hamsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cage_Buddies_CageId",
                table: "Cage_Buddies",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cage_Buddies_GenderInCageId",
                table: "Cage_Buddies",
                column: "GenderInCageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_ActivityId",
                table: "Hamsters",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_Cage_BuddiesId",
                table: "Hamsters",
                column: "Cage_BuddiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_ExerciseAreaId",
                table: "Hamsters",
                column: "ExerciseAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_GenderId",
                table: "Hamsters",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_OwnerId",
                table: "Hamsters",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logg_Activities_ActivityId",
                table: "Logg_Activities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Logg_Activities_HamsterId",
                table: "Logg_Activities",
                column: "HamsterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logg_Activities");

            migrationBuilder.DropTable(
                name: "Hamsters");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Cage_Buddies");

            migrationBuilder.DropTable(
                name: "ExerciseAreas");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
