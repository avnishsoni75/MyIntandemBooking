using Microsoft.EntityFrameworkCore.Migrations;

namespace MyIntandemBooking.Migrations
{
    public partial class ManAssignPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_ManagerAssignment_ID",
                table: "ManagerAssignment",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ManagerAssignment_ID",
                table: "ManagerAssignment");
        }
    }
}
