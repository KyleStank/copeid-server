using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CopeID.Context.Migrations
{
    public partial class AddedForeignKeyToFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityProperty",
                table: "FilterSections");

            migrationBuilder.DropColumn(
                name: "EntityPropertyType",
                table: "FilterSections");

            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "Filters");

            migrationBuilder.AddColumn<Guid>(
                name: "FilterModelId",
                table: "Filters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Filters_FilterModelId",
                table: "Filters",
                column: "FilterModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_FilterModels_FilterModelId",
                table: "Filters",
                column: "FilterModelId",
                principalTable: "FilterModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filters_FilterModels_FilterModelId",
                table: "Filters");

            migrationBuilder.DropIndex(
                name: "IX_Filters_FilterModelId",
                table: "Filters");

            migrationBuilder.DropColumn(
                name: "FilterModelId",
                table: "Filters");

            migrationBuilder.AddColumn<string>(
                name: "EntityProperty",
                table: "FilterSections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EntityPropertyType",
                table: "FilterSections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EntityType",
                table: "Filters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
