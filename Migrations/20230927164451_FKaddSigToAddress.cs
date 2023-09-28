using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Op_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FKaddSigToAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AttractionId",
                table: "Addresses",
                column: "AttractionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_SightSeeings_AttractionId",
                table: "Addresses",
                column: "AttractionId",
                principalTable: "SightSeeings",
                principalColumn: "AttractionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_SightSeeings_AttractionId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AttractionId",
                table: "Addresses");
        }
    }
}
