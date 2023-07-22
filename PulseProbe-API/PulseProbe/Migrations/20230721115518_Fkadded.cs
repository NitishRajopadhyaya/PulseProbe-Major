using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PulseProbe.Migrations
{
    /// <inheritdoc />
    public partial class Fkadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DId",
                table: "TimeSchedule",
                newName: "DoctorId");

            migrationBuilder.AlterColumn<string>(
                name: "StartingTime",
                table: "TimeSchedule",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "EndingTime",
                table: "TimeSchedule",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSchedule_DoctorId",
                table: "TimeSchedule",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSchedule_Doctor_DoctorId",
                table: "TimeSchedule",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSchedule_Doctor_DoctorId",
                table: "TimeSchedule");

            migrationBuilder.DropIndex(
                name: "IX_TimeSchedule_DoctorId",
                table: "TimeSchedule");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "TimeSchedule",
                newName: "DId");

            migrationBuilder.AlterColumn<string>(
                name: "StartingTime",
                table: "TimeSchedule",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndingTime",
                table: "TimeSchedule",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
