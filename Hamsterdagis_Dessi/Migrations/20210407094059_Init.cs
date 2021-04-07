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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountInCage = table.Column<int>(type: "int", nullable: false)
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
                name: "Hamsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hamster_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: true),
                    CageId = table.Column<int>(type: "int", nullable: true),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTimeExercise = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTimeExercise = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalTimeWaited = table.Column<TimeSpan>(type: "time", nullable: true),
                    TimeWaited = table.Column<TimeSpan>(type: "time", nullable: true),
                    AmountOfExercises = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Hamsters_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
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
                        name: "FK_Hamsters_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logg_Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HamsterId = table.Column<int>(type: "int", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Arrival" },
                    { 2, "DayCage" },
                    { 3, "Exercise" },
                    { 4, "PickUp" }
                });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "Id", "AmountInCage" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 0 },
                    { 3, 0 },
                    { 4, 0 },
                    { 5, 0 },
                    { 6, 0 },
                    { 7, 0 },
                    { 8, 0 },
                    { 9, 0 },
                    { 10, 0 }
                });

            migrationBuilder.InsertData(
                table: "ExerciseAreas",
                columns: new[] { "Id", "AmountInArea" },
                values: new object[] { 1, 0 });

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
                    { 24, "Anna Linström" },
                    { 23, "Mia Eriksson" },
                    { 22, "Carita Gran" },
                    { 21, "Hans Björk" },
                    { 20, "Anna Al" },
                    { 19, "Bo Ek" },
                    { 18, "Pia Hansson" },
                    { 17, "GW Hansson" },
                    { 16, "Mindy Mendel" },
                    { 15, "Mork of Ork" },
                    { 14, "Kim Carnes" },
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
                    { 12, "Hedy Lamar" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name" },
                values: new object[] { 26, "Bo Bergman" });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "Id", "ActivityId", "Age", "AmountOfExercises", "CageId", "CheckInTime", "EndTimeExercise", "ExerciseAreaId", "GenderId", "Hamster_Name", "OwnerId", "StartTimeExercise", "TimeWaited", "TotalTimeWaited" },
                values: new object[,]
                {
                    { 1, null, 4, 0, null, null, null, null, 2, "Rufus", 1, null, null, null },
                    { 28, null, 8, 0, null, null, null, null, 2, "Marvel", 24, null, null, null },
                    { 27, null, 9, 0, null, null, null, null, 1, "Mimmi", 23, null, null, null },
                    { 26, null, 110, 0, null, null, null, null, 2, "Crawler", 22, null, null, null },
                    { 25, null, 12, 0, null, null, null, null, 1, "Gittan", 21, null, null, null },
                    { 24, null, 14, 0, null, null, null, null, 2, "Sauron", 20, null, null, null },
                    { 23, null, 15, 0, null, null, null, null, 2, "Clint", 19, null, null, null },
                    { 22, null, 16, 0, null, null, null, null, 1, "Neko", 18, null, null, null },
                    { 21, null, 16, 0, null, null, null, null, 1, "Fiffi", 17, null, null, null },
                    { 20, null, 18, 0, null, null, null, null, 1, "Ruby", 16, null, null, null },
                    { 19, null, 19, 0, null, null, null, null, 1, "Kimber", 15, null, null, null },
                    { 18, null, 20, 0, null, null, null, null, 1, "Amber", 14, null, null, null },
                    { 17, null, 21, 0, null, null, null, null, 1, "Robin", 13, null, null, null },
                    { 16, null, 22, 0, null, null, null, null, 1, "Bobo", 12, null, null, null },
                    { 15, null, 23, 0, null, null, null, null, 2, "Beppe", 11, null, null, null },
                    { 14, null, 24, 0, null, null, null, null, 2, "Bulle", 10, null, null, null },
                    { 13, null, 3, 0, null, null, null, null, 1, "Malin", 9, null, null, null },
                    { 12, null, 3, 0, null, null, null, null, 2, "Chivas", 8, null, null, null },
                    { 11, null, 4, 0, null, null, null, null, 1, "Starlight", 7, null, null, null },
                    { 10, null, 4, 0, null, null, null, null, 2, "Kurt", 7, null, null, null },
                    { 9, null, 5, 0, null, null, null, null, 2, "Kalle", 6, null, null, null },
                    { 8, null, 6, 0, null, null, null, null, 1, "Miss Diggy", 5, null, null, null },
                    { 7, null, 7, 0, null, null, null, null, 1, "Mulan", 4, null, null, null },
                    { 6, null, 8, 0, null, null, null, null, 1, "Sussi", 3, null, null, null },
                    { 5, null, 9, 0, null, null, null, null, 2, "Sneaky", 3, null, null, null },
                    { 4, null, 10, 0, null, null, null, null, 2, "Nibbler", 2, null, null, null },
                    { 3, null, 11, 0, null, null, null, null, 2, "Fluff", 2, null, null, null },
                    { 2, null, 12, 0, null, null, null, null, 1, "Lisa", 1, null, null, null },
                    { 29, null, 7, 0, null, null, null, null, 2, "Storm", 25, null, null, null },
                    { 30, null, 6, 0, null, null, null, null, 1, "Busan", 26, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_ActivityId",
                table: "Hamsters",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_CageId",
                table: "Hamsters",
                column: "CageId");

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
                name: "Cages");

            migrationBuilder.DropTable(
                name: "ExerciseAreas");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
