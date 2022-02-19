using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaroleRestApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BarotraumaRoles",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("2487ebde-1e7f-4c14-8bdd-b4327bcddcf2"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("04731f90-3dc3-4371-8669-6306b6d70562"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BarotraumaRoles",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("04731f90-3dc3-4371-8669-6306b6d70562"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("2487ebde-1e7f-4c14-8bdd-b4327bcddcf2"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
