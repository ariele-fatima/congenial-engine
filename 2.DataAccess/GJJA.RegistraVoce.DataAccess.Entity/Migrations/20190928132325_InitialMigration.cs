using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GJJA.RegistraVoce.DataAccess.Entity.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PEO_PEOPLE",
                columns: table => new
                {
                    PEO_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PEO_NAME = table.Column<string>(maxLength: 50, nullable: false),
                    PEO_GENDER = table.Column<int>(nullable: false),
                    PEO_DOCUMETNNUMBER = table.Column<string>(maxLength: 11, nullable: false),
                    PEO_IDENTIFICATION = table.Column<string>(maxLength: 15, nullable: false),
                    PEO_BIRTHDATE = table.Column<DateTime>(nullable: false),
                    PEO_MARITAL_STATUS = table.Column<int>(nullable: false),
                    PEO_ADDRESS = table.Column<string>(maxLength: 100, nullable: true),
                    PEO_PHONE = table.Column<string>(maxLength: 12, nullable: true),
                    Bla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEO_PEOPLE", x => x.PEO_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PEO_PEOPLE");
        }
    }
}
