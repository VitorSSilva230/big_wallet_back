using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace big_wallet.Migrations
{
    /// <inheritdoc />
    public partial class @continue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "date_registration",
                table: "User",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "time_registration",
                table: "User",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "time_registration",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_registration",
                table: "User",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
