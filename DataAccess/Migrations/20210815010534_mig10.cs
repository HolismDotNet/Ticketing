using Microsoft.EntityFrameworkCore.Migrations;

namespace Holism.Ticketing.DataAccess.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersianDate",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersianDate",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
