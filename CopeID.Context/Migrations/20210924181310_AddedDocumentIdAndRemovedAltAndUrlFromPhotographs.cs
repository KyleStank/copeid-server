using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CopeID.Context.Migrations
{
    public partial class AddedDocumentIdAndRemovedAltAndUrlFromPhotographs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alt",
                table: "Photographs");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Photographs");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Photographs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentId",
                table: "Photographs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Photographs_DocumentId",
                table: "Photographs",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photographs_Documents_DocumentId",
                table: "Photographs",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photographs_Documents_DocumentId",
                table: "Photographs");

            migrationBuilder.DropIndex(
                name: "IX_Photographs_DocumentId",
                table: "Photographs");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Photographs");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Photographs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Alt",
                table: "Photographs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Photographs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
