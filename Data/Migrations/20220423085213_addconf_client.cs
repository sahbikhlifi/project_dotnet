using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addconf_client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Categories_CategoryId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "ClientDocument");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Categories_CategoryId",
                table: "Clients",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Categories_CategoryId",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "ClientDocument",
                columns: table => new
                {
                    ClientsClientId = table.Column<int>(type: "int", nullable: false),
                    DocumentsKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDocument", x => new { x.ClientsClientId, x.DocumentsKey });
                    table.ForeignKey(
                        name: "FK_ClientDocument_Clients_ClientsClientId",
                        column: x => x.ClientsClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientDocument_Documents_DocumentsKey",
                        column: x => x.DocumentsKey,
                        principalTable: "Documents",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDocument_DocumentsKey",
                table: "ClientDocument",
                column: "DocumentsKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Categories_CategoryId",
                table: "Clients",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
