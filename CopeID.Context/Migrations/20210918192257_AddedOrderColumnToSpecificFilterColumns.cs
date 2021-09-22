using Microsoft.EntityFrameworkCore.Migrations;

namespace CopeID.Context.Migrations
{
    public partial class AddedOrderColumnToSpecificFilterColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "FilterSections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "FilterSectionParts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "FilterSectionPartOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "FilterSections");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "FilterSectionParts");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "FilterSectionPartOptions");
        }
    }
}
