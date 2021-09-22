using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CopeID.Context.Migrations
{
    public partial class MovedFilterModelPropertyIdFromFilterSectionToFilterSectionPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "FilterModelPropertyId",
                table: "FilterSectionParts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilterSectionParts_FilterModelPropertyId",
                table: "FilterSectionParts",
                column: "FilterModelPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilterSectionParts_FilterModelProperties_FilterModelPropertyId",
                table: "FilterSectionParts",
                column: "FilterModelPropertyId",
                principalTable: "FilterModelProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilterSectionParts_FilterModelProperties_FilterModelPropertyId",
                table: "FilterSectionParts");

            migrationBuilder.DropIndex(
                name: "IX_FilterSectionParts_FilterModelPropertyId",
                table: "FilterSectionParts");

            migrationBuilder.DropColumn(
                name: "FilterModelPropertyId",
                table: "FilterSectionParts");

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
    }
}
