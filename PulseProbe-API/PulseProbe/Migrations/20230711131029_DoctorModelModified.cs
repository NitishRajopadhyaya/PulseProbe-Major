using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PulseProbe.Migrations
{
    /// <inheritdoc />
    public partial class DoctorModelModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Certificate",
                table: "Doctor",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Doctor",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Doctor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "Doctor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Doctor");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Doctor",
                newName: "Certificate");
        }
    }
}
