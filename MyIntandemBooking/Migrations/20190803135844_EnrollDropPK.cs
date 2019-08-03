using Microsoft.EntityFrameworkCore.Migrations;

namespace MyIntandemBooking.Migrations
{
    public partial class EnrollDropPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "Enrollment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Enrollment",
                nullable: false,
                defaultValue: 0);
        }
    }
}
