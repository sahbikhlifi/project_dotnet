using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class update_Key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts");

            migrationBuilder.DropColumn(
                name: "key",
                table: "Emprunts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts",
                columns: new[] { "DateEmprunt", "ClientFk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts");

            migrationBuilder.AddColumn<int>(
                name: "key",
                table: "Emprunts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emprunts",
                table: "Emprunts",
                columns: new[] { "DateEmprunt", "key", "ClientFk" });
        }
    }
}
