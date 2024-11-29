using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OIC_FK31.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFacilityphotoPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacilityphotoPath",
                table: "Facility",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacilityphotoPath",
                table: "Facility");
        }
    }
}
