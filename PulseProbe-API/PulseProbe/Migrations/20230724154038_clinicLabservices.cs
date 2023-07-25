using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PulseProbe.Migrations
{
    /// <inheritdoc />
    public partial class clinicLabservices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Laltitude",
                table: "Lab",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Lab",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ServicesProvided",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesProvided", x => x.ServiceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesProvided");

            migrationBuilder.DropColumn(
                name: "Laltitude",
                table: "Lab");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Lab");
        }
    }
}
