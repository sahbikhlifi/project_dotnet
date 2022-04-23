using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts",
                columns: new[] { "DateEmprunt", "ClientFk", "DocumentFk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts",
                columns: new[] { "DateEmprunt", "ClientFk" });
        }
    }
}
