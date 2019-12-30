using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleEFCore.Data.Migrations
{
    public partial class added_N_N_Living_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SamuraiLivingLivingId",
                table: "Samurais",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SamuraiLivingSamuraiId",
                table: "Samurais",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SamuraiLivingLivingId",
                table: "SamuraiLivingDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SamuraiLivingSamuraiId",
                table: "SamuraiLivingDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SamuraiLivings",
                columns: table => new
                {
                    LivingId = table.Column<int>(nullable: false),
                    SamuraiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraiLivings", x => new { x.LivingId, x.SamuraiId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_SamuraiLivingLivingId_SamuraiLivingSamuraiId",
                table: "Samurais",
                columns: new[] { "SamuraiLivingLivingId", "SamuraiLivingSamuraiId" });

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiLivingDetails_SamuraiLivingLivingId_SamuraiLivingSamuraiId",
                table: "SamuraiLivingDetails",
                columns: new[] { "SamuraiLivingLivingId", "SamuraiLivingSamuraiId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiLivingDetails_SamuraiLivings_SamuraiLivingLivingId_SamuraiLivingSamuraiId",
                table: "SamuraiLivingDetails",
                columns: new[] { "SamuraiLivingLivingId", "SamuraiLivingSamuraiId" },
                principalTable: "SamuraiLivings",
                principalColumns: new[] { "LivingId", "SamuraiId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_SamuraiLivings_SamuraiLivingLivingId_SamuraiLivingSamuraiId",
                table: "Samurais",
                columns: new[] { "SamuraiLivingLivingId", "SamuraiLivingSamuraiId" },
                principalTable: "SamuraiLivings",
                principalColumns: new[] { "LivingId", "SamuraiId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiLivingDetails_SamuraiLivings_SamuraiLivingLivingId_SamuraiLivingSamuraiId",
                table: "SamuraiLivingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_SamuraiLivings_SamuraiLivingLivingId_SamuraiLivingSamuraiId",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "SamuraiLivings");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_SamuraiLivingLivingId_SamuraiLivingSamuraiId",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_SamuraiLivingDetails_SamuraiLivingLivingId_SamuraiLivingSamuraiId",
                table: "SamuraiLivingDetails");

            migrationBuilder.DropColumn(
                name: "SamuraiLivingLivingId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "SamuraiLivingSamuraiId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "SamuraiLivingLivingId",
                table: "SamuraiLivingDetails");

            migrationBuilder.DropColumn(
                name: "SamuraiLivingSamuraiId",
                table: "SamuraiLivingDetails");
        }
    }
}
