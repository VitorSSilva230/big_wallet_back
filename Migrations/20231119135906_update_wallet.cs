using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace big_wallet.Migrations
{
    /// <inheritdoc />
    public partial class update_wallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_coin",
                table: "Wallet");

            migrationBuilder.AddColumn<string>(
                name: "id_key_coin",
                table: "Wallet",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_key_coin",
                table: "Wallet");

            migrationBuilder.AddColumn<int>(
                name: "id_coin",
                table: "Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
