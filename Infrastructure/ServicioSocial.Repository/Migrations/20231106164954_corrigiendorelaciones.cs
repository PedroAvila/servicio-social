using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioSocial.Repository.Migrations
{
    public partial class corrigiendorelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialServices_Users_UserId",
                table: "SocialServices");

            migrationBuilder.DropIndex(
                name: "IX_SocialServices_UserId",
                table: "SocialServices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SocialServices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SocialServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SocialServices_UserId",
                table: "SocialServices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServices_Users_UserId",
                table: "SocialServices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
