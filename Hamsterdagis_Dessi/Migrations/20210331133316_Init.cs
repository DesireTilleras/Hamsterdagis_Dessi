using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hamsterdagis_Dessi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Logg_Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logg_Activities", x => x.Id);
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
                    CageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cage_Buddies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cage_Buddies_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logg_ActivitiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Logg_Activities_Logg_ActivitiesId",
                        column: x => x.Logg_ActivitiesId,
                        principalTable: "Logg_Activities",
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
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: true),
                    Cage_BuddiesId = table.Column<int>(type: "int", nullable: true),
                    ExerciseAreaId = table.Column<int>(type: "int", nullable: true),
                    Logg_ActivitiesId = table.Column<int>(type: "int", nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hamsters_Logg_Activities_Logg_ActivitiesId",
                        column: x => x.Logg_ActivitiesId,
                        principalTable: "Logg_Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Logg_ActivitiesId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Arrival" },
                    { 2, null, "DayCage" },
                    { 3, null, "Exercise" },
                    { 4, null, "PickUp" }
                });

            migrationBuilder.InsertData(
                table: "Cages",
                column: "Id",
                values: new object[]
                {
                    9,
                    8,
                    7,
                    6,
                    10,
                    4,
                    3,
                    2,
                    1,
                    5
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Gender_Type" },
                values: new object[,]
                {
                    { 1, "Female" },
                    { 2, "Male" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 15, "Mork of Ork" },
                    { 16, "Mindy Mendel" },
                    { 17, "GW Hansson" },
                    { 18, "Pia Hansson" },
                    { 19, "Bo Ek" },
                    { 22, "Carita Gran" },
                    { 21, "Hans Björk" },
                    { 23, "Mia Eriksson" },
                    { 24, "Anna Linström" },
                    { 14, "Kim Carnes" },
                    { 20, "Anna Al" },
                    { 13, "Bette Davis" },
                    { 5, "Ottilla Murkwood" },
                    { 11, "Bobby Ewing" },
                    { 10, "Lorenzo Lamas" },
                    { 9, "Bianca Ingrosso" },
                    { 8, "Pernilla Wahlgren" },
                    { 7, "Anna Book" },
                    { 6, "Anfers Murkwood" },
                    { 25, "Lennart Berg" },
                    { 4, "Jan Hallgren" },
                    { 3, "Lisa Nilsson" },
                    { 2, "Carl Hamilton" },
                    { 1, "Kallegurra Aktersnurra" },
                    { 12, "Hedy Lamar" },
                    { 26, "Bo Bergman" }
                });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "Id", "ActivityId", "Age", "Cage_BuddiesId", "CheckInTime", "ExerciseAreaId", "GenderId", "Hamster_Name", "Logg_ActivitiesId", "OwnerId", "TimeForLastExercise" },
                values: new object[,]
                {
                    { 1, null, 4, null, null, null, 2, "Rufus", null, 1, null },
                    { 28, null, 8, null, null, null, 2, "Marvel", null, 24, null },
                    { 27, null, 9, null, null, null, 1, "Mimmi", null, 23, null },
                    { 26, null, 110, null, null, null, 2, "Crawler", null, 22, null },
                    { 25, null, 12, null, null, null, 1, "Gittan", null, 21, null },
                    { 24, null, 14, null, null, null, 2, "Sauron", null, 20, null },
                    { 23, null, 15, null, null, null, 2, "Clint", null, 19, null },
                    { 22, null, 16, null, null, null, 1, "Neko", null, 18, null },
                    { 21, null, 16, null, null, null, 1, "Fiffi", null, 17, null },
                    { 20, null, 18, null, null, null, 1, "Ruby", null, 16, null },
                    { 19, null, 19, null, null, null, 1, "Kimber", null, 15, null },
                    { 18, null, 20, null, null, null, 1, "Amber", null, 14, null },
                    { 17, null, 21, null, null, null, 1, "Robin", null, 13, null },
                    { 16, null, 22, null, null, null, 1, "Bobo", null, 12, null },
                    { 15, null, 23, null, null, null, 2, "Beppe", null, 11, null },
                    { 14, null, 24, null, null, null, 2, "Bulle", null, 10, null },
                    { 13, null, 3, null, null, null, 1, "Malin", null, 9, null },
                    { 12, null, 3, null, null, null, 2, "Chivas", null, 8, null },
                    { 11, null, 4, null, null, null, 1, "Starlight", null, 7, null },
                    { 10, null, 4, null, null, null, 2, "Kurt", null, 7, null },
                    { 9, null, 5, null, null, null, 2, "Kalle", null, 6, null },
                    { 8, null, 6, null, null, null, 1, "Miss Diggy", null, 5, null },
                    { 7, null, 7, null, null, null, 1, "Mulan", null, 4, null },
                    { 6, null, 8, null, null, null, 1, "Sussi", null, 3, null },
                    { 5, null, 9, null, null, null, 2, "Sneaky", null, 3, null },
                    { 4, null, 10, null, null, null, 2, "Nibbler", null, 2, null },
                    { 3, null, 11, null, null, null, 2, "Fluff", null, 2, null },
                    { 2, null, 12, null, null, null, 1, "Lisa", null, 1, null },
                    { 29, null, 7, null, null, null, 2, "Storm", null, 25, null },
                    { 30, null, 6, null, null, null, 1, "Busan", null, 26, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Logg_ActivitiesId",
                table: "Activities",
                column: "Logg_ActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Cage_Buddies_CageId",
                table: "Cage_Buddies",
                column: "CageId");

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
                name: "IX_Hamsters_Logg_ActivitiesId",
                table: "Hamsters",
                column: "Logg_ActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_OwnerId",
                table: "Hamsters",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hamsters");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Cage_Buddies");

            migrationBuilder.DropTable(
                name: "ExerciseAreas");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Logg_Activities");

            migrationBuilder.DropTable(
                name: "Cages");
        }
    }
}
