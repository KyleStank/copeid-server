using Microsoft.EntityFrameworkCore.Migrations;

namespace CopeID.Context.Migrations
{
    public partial class AddedNewColumnsToSpecimens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Thorax",
                table: "Specimens",
                newName: "UrosomeDescription");

            migrationBuilder.AlterColumn<int>(
                name: "Urosome",
                table: "Specimens",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Setea",
                table: "Specimens",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Furca",
                table: "Specimens",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Eyes",
                table: "Specimens",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cephalosome",
                table: "Specimens",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AntenuleDescription",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyShapeDescription",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CephalosomeDescription",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EyesDescription",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FurcaDescription",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RostrumDescription",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeteaDescription",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThoraxDescription",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThoraxSegments",
                table: "Specimens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThoraxShape",
                table: "Specimens",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AntenuleDescription",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "BodyShapeDescription",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "CephalosomeDescription",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "EyesDescription",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "FurcaDescription",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "RostrumDescription",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "SeteaDescription",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "ThoraxDescription",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "ThoraxSegments",
                table: "Specimens");

            migrationBuilder.DropColumn(
                name: "ThoraxShape",
                table: "Specimens");

            migrationBuilder.RenameColumn(
                name: "UrosomeDescription",
                table: "Specimens",
                newName: "Thorax");

            migrationBuilder.AlterColumn<string>(
                name: "Urosome",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Setea",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Furca",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Eyes",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cephalosome",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
