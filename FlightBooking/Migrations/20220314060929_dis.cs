using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightBooking.Migrations
{
    public partial class dis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountApplied",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "DiscountCode",
                table: "Bookings",
                newName: "Discount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Bookings",
                newName: "DiscountCode");

            migrationBuilder.AddColumn<bool>(
                name: "DiscountApplied",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
