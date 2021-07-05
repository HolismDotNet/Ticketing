using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Holism.Ticketing.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttachedFiles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PostId = table.Column<long>(nullable: false),
                    FileGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachedFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostHtmls",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Html = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostHtmls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    TicketId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    PersianDate = table.Column<string>(nullable: true),
                    IsSystemPost = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachedFiles");

            migrationBuilder.DropTable(
                name: "PostHtmls");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
