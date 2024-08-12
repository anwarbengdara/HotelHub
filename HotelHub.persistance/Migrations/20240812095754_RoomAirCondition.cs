using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelHub.persistance.Migrations
{
    /// <inheritdoc />
    public partial class RoomAirCondition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotel_HotelID",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "HotelID",
                table: "Rooms",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HotelID",
                table: "Rooms",
                newName: "IX_Rooms_HotelId");

            migrationBuilder.AddColumn<bool>(
                name: "AirCondition",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotel",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotel_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotel_HotelId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AirCondition",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Rooms",
                newName: "HotelID");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                newName: "IX_Rooms_HotelID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)",
                oldMaxLength: 24);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotel_HotelID",
                table: "Rooms",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
