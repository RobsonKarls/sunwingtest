using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ContactManager.API.Migrations
{
    public partial class migrationsaddtablefornames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_First",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Name_Last",
                table: "Person");

            migrationBuilder.CreateTable(
                name: "Name",
                columns: table => new
                {
                    PersonId = table.Column<long>(nullable: false),
                    First = table.Column<string>(nullable: true),
                    Last = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Name", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Name_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name_First",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Last",
                table: "Person",
                nullable: true);
        }
    }
}
