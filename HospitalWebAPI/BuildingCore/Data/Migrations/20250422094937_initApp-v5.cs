using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingCore.data.Migrations
{
    /// <inheritdoc />
    public partial class initAppv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "Version",
        table: "Customers");

            // Thêm lại với kiểu rowversion
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Customers",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "Version",
        table: "Customers");

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Customers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
