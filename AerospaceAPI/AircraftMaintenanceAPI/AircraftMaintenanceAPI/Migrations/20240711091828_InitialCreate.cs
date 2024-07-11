using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftMaintenanceAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastMaintenanceDate",
                value: new DateTime(2024, 7, 11, 2, 18, 28, 313, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastMaintenanceDate",
                value: new DateTime(2024, 7, 11, 2, 18, 28, 313, DateTimeKind.Local).AddTicks(6303));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastMaintenanceDate",
                value: new DateTime(2024, 7, 11, 2, 16, 16, 616, DateTimeKind.Local).AddTicks(3896));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastMaintenanceDate",
                value: new DateTime(2024, 7, 11, 2, 16, 16, 616, DateTimeKind.Local).AddTicks(3907));
        }
    }
}
