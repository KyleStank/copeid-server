using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CopeID.Context.Migrations
{
    public partial class FilterSectionPartModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilterSectionOptions");

            migrationBuilder.CreateTable(
                name: "FilterSectionParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilterSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterSectionParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilterSectionParts_FilterSections_FilterSectionId",
                        column: x => x.FilterSectionId,
                        principalTable: "FilterSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterSectionPartOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilterSectionPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterSectionPartOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilterSectionPartOptions_FilterSectionParts_FilterSectionPartId",
                        column: x => x.FilterSectionPartId,
                        principalTable: "FilterSectionParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilterSectionPartOptions_FilterSectionPartId",
                table: "FilterSectionPartOptions",
                column: "FilterSectionPartId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterSectionParts_FilterSectionId",
                table: "FilterSectionParts",
                column: "FilterSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilterSectionPartOptions");

            migrationBuilder.DropTable(
                name: "FilterSectionParts");

            migrationBuilder.CreateTable(
                name: "FilterSectionOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilterSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterSectionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilterSectionOptions_FilterSections_FilterSectionId",
                        column: x => x.FilterSectionId,
                        principalTable: "FilterSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilterSectionOptions_FilterSectionId",
                table: "FilterSectionOptions",
                column: "FilterSectionId");
        }
    }
}
