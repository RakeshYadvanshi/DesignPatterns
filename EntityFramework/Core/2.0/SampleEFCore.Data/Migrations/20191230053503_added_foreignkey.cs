using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleEFCore.Data.Migrations
{
    public partial class added_foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SamuraiLivings_Samurai",
                table: "SamuraiLivings",
                column: "Samurai");

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiLivings_SamuraiLivingDetails_Living",
                table: "SamuraiLivings",
                column: "Living",
                principalTable: "SamuraiLivingDetails",
                principalColumn: "LivingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiLivings_Samurais_Samurai",
                table: "SamuraiLivings",
                column: "Samurai",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiLivings_SamuraiLivingDetails_Living",
                table: "SamuraiLivings");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiLivings_Samurais_Samurai",
                table: "SamuraiLivings");

            migrationBuilder.DropIndex(
                name: "IX_SamuraiLivings_Samurai",
                table: "SamuraiLivings");
        }
    }
}
