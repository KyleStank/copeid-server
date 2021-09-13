using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CopeID.Context.Migrations
{
    public partial class AddFilterModelPropertyIdToFilterSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "FilterSections",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "FilterSections",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "FilterModelPropertyId",
                table: "FilterSections",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilterSections_FilterModelPropertyId",
                table: "FilterSections",
                column: "FilterModelPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilterSections_FilterModelProperties_FilterModelPropertyId",
                table: "FilterSections",
                column: "FilterModelPropertyId",
                principalTable: "FilterModelProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilterSections_FilterModelProperties_FilterModelPropertyId",
                table: "FilterSections");

            migrationBuilder.DropIndex(
                name: "IX_FilterSections_FilterModelPropertyId",
                table: "FilterSections");

            migrationBuilder.DropColumn(
                name: "FilterModelPropertyId",
                table: "FilterSections");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "FilterSections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "FilterSections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
