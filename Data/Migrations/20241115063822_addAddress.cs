using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OIC_FK31.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtendedAddress",
                table: "UserDetail");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "UserDetail",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "UserDetail",
                newName: "StreetAddress");

            migrationBuilder.AddColumn<string>(
                name: "ExtendedAddress",
                table: "UserDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
