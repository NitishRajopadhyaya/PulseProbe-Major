using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PulseProbe.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientImage",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Lab");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Lab",
                newName: "state");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Patient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Municiplaity",
                table: "Patient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientMiddleName",
                table: "Patient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WardNo",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "Patient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Municiplaity",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PatientMiddleName",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "WardNo",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "state",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Lab",
                newName: "Province");

            migrationBuilder.AddColumn<string>(
                name: "PatientImage",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Lab",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
