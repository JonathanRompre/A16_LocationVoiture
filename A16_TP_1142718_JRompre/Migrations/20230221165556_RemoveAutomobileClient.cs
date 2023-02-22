using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A16_TP_1142718_JRompre.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAutomobileClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobile_Client_clientId",
                table: "Automobile");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Automobile",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Automobile_clientId",
                table: "Automobile",
                newName: "IX_Automobile_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobile_Client_ClientId",
                table: "Automobile",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobile_Client_ClientId",
                table: "Automobile");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Automobile",
                newName: "clientId");

            migrationBuilder.RenameIndex(
                name: "IX_Automobile_ClientId",
                table: "Automobile",
                newName: "IX_Automobile_clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobile_Client_clientId",
                table: "Automobile",
                column: "clientId",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
