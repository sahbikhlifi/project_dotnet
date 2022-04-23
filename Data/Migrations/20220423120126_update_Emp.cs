using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class update_Emp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts",
                columns: new[] { "DateEmprunt", "key", "ClientFk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts",
                columns: new[] { "DateEmprunt", "key" });
        }
    }
}
