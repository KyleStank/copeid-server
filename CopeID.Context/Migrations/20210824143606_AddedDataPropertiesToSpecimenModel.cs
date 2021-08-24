using Microsoft.EntityFrameworkCore.Migrations;

namespace CopeID.Context.Migrations
{
    public partial class AddedDataPropertiesToSpecimenModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Antenule",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyShape",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cephalosome",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Eyes",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Furca",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rostrum",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Setea",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialCharacteristics",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thorax",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Urosome",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Antenule",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "BodyShape",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "Cephalosome",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "Eyes",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "Furca",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "Rostrum",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "Setea",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "SpecialCharacteristics",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "Thorax",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "Urosome",
                table: "Specimens");
        }
    }
}
