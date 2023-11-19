using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace big_wallet.Migrations
{
    /// <inheritdoc />
    public partial class update_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "id_coin",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "last_value",
                table: "Transaction",
                newName: "quantity_base_coin");

            migrationBuilder.AddColumn<DateOnly>(
                name: "date_transaction",
                table: "Transaction",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<double>(
                name: "quantity_acquired_coin",
                table: "Transaction",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "time_transaction",
                table: "Transaction",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_transaction",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "quantity_acquired_coin",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "time_transaction",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "quantity_base_coin",
                table: "Transaction",
                newName: "last_value");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Transaction",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "id_coin",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
