using Microsoft.EntityFrameworkCore.Migrations;

namespace MyIntandemBooking.Migrations
{
    public partial class ManagerAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Event_EventID",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_EventID",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Event");

            migrationBuilder.CreateTable(
                name: "ManagerAssignment",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerAssignment", x => new { x.UserID, x.EventID });
                    table.ForeignKey(
                        name: "FK_ManagerAssignment_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerAssignment_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManagerAssignment_EventID",
                table: "ManagerAssignment",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagerAssignment");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Event",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventID",
                table: "Event",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Event_EventID",
                table: "Event",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
