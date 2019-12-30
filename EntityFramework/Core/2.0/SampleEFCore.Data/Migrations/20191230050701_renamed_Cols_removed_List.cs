using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleEFCore.Data.Migrations
{
    public partial class renamed_Cols_removed_List : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiLivingDetails_SamuraiLivings_SamuraiLivingLivingId_SamuraiLivingSamuraiId",
                table: "SamuraiLivingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_SamuraiLivings_SamuraiLivingLivingId_SamuraiLivingSamuraiId",
                table: "Samurais");

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

            migrationBuilder.RenameColumn(
                name: "SamuraiId",
                table: "SamuraiLivings",
                newName: "Samurai");

            migrationBuilder.RenameColumn(
                name: "LivingId",
                table: "SamuraiLivings",
                newName: "Living");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Samurai",
                table: "SamuraiLivings",
                newName: "SamuraiId");

            migrationBuilder.RenameColumn(
                name: "Living",
                table: "SamuraiLivings",
                newName: "LivingId");

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
    }
}
