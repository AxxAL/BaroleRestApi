using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaroleRestApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarotraumaRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    BarotraumaJob = table.Column<string>(type: "TEXT", nullable: false),
                    Goal = table.Column<string>(type: "TEXT", nullable: false),
                    WinCondition = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "TEXT", nullable: true),
                    Tips = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarotraumaRoles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarotraumaRoles");
        }
    }
}
