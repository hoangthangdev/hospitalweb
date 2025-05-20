using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingCore.data.Migrations
{
    /// <inheritdoc />
    public partial class initAppv8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Specialties_SpecialtyId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "BuildingCore.Data.IApplicationDbContext.Patients");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "BuildingCore.Data.IApplicationDbContext.Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserId",
                table: "BuildingCore.Data.IApplicationDbContext.Employees",
                newName: "IX_BuildingCore.Data.IApplicationDbContext.Employees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_SpecialtyId",
                table: "BuildingCore.Data.IApplicationDbContext.Employees",
                newName: "IX_BuildingCore.Data.IApplicationDbContext.Employees_SpecialtyId");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialtyId",
                table: "BuildingCore.Data.IApplicationDbContext.Employees",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingCore.Data.IApplicationDbContext.Patients",
                table: "BuildingCore.Data.IApplicationDbContext.Patients",
                column: "PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingCore.Data.IApplicationDbContext.Employees",
                table: "BuildingCore.Data.IApplicationDbContext.Employees",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingCore.Data.IApplicationDbContext.Employees_AspNetUsers_UserId",
                table: "BuildingCore.Data.IApplicationDbContext.Employees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingCore.Data.IApplicationDbContext.Employees_Specialties_SpecialtyId",
                table: "BuildingCore.Data.IApplicationDbContext.Employees",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingCore.Data.IApplicationDbContext.Employees_AspNetUsers_UserId",
                table: "BuildingCore.Data.IApplicationDbContext.Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingCore.Data.IApplicationDbContext.Employees_Specialties_SpecialtyId",
                table: "BuildingCore.Data.IApplicationDbContext.Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingCore.Data.IApplicationDbContext.Patients",
                table: "BuildingCore.Data.IApplicationDbContext.Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingCore.Data.IApplicationDbContext.Employees",
                table: "BuildingCore.Data.IApplicationDbContext.Employees");

            migrationBuilder.RenameTable(
                name: "BuildingCore.Data.IApplicationDbContext.Patients",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "BuildingCore.Data.IApplicationDbContext.Employees",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingCore.Data.IApplicationDbContext.Employees_UserId",
                table: "Employees",
                newName: "IX_Employees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingCore.Data.IApplicationDbContext.Employees_SpecialtyId",
                table: "Employees",
                newName: "IX_Employees_SpecialtyId");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpecialtyId",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Specialties_SpecialtyId",
                table: "Employees",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
