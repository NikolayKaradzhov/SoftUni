using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Migrations
{
    public partial class ChangeAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Bets",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Bets",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
