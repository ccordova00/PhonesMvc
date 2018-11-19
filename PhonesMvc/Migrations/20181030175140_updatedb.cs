using Microsoft.EntityFrameworkCore.Migrations;

namespace PhonesMvc.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sim",
                table: "Phone",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Sim",
                table: "Phone",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
