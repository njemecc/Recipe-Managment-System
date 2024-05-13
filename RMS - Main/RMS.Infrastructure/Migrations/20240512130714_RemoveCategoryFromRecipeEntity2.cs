using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCategoryFromRecipeEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Recipes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
