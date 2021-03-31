using Microsoft.EntityFrameworkCore.Migrations;

namespace Hamsterdagis_Dessi.Migrations
{
    public partial class updating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cage_Id",
                table: "Cages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cage_Id",
                table: "Cages");
        }
    }
}
