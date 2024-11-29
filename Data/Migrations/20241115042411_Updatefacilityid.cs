using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OIC_FK31.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatefacilityid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "FacilityID",
                table: "Time",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "Time");

            migrationBuilder.AddColumn<int>(
                name: "FacilityID",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
