using Microsoft.EntityFrameworkCore.Migrations;

namespace MyIntandemBooking.Migrations
{
    public partial class ManAssignDropPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ManagerAssignment_ID",
                table: "ManagerAssignment");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ManagerAssignment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ManagerAssignment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ManagerAssignment_ID",
                table: "ManagerAssignment",
                column: "ID");
        }
    }
}
