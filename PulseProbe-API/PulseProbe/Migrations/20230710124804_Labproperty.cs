using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PulseProbe.Migrations
{
    /// <inheritdoc />
    public partial class Labproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClinicJoinedDate",
                table: "Doctor");

            migrationBuilder.RenameColumn(
                name: "LicenseNumber",
                table: "Doctor",
                newName: "NMCNumber");

            migrationBuilder.CreateTable(
                name: "Lab",
                columns: table => new
                {
                    LabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicsenceNumber = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.LabId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lab");

            migrationBuilder.RenameColumn(
                name: "NMCNumber",
                table: "Doctor",
                newName: "LicenseNumber");

            migrationBuilder.AddColumn<string>(
                name: "ClinicJoinedDate",
                table: "Doctor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
