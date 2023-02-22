using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A16_TP_1142718_JRompre.Migrations
{
    /// <inheritdoc />
    public partial class unwantedColumnCleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Automobile_Client_ClientId", "Automobile");
            migrationBuilder.DropColumn(name: "ClientId", table: "Automobile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
