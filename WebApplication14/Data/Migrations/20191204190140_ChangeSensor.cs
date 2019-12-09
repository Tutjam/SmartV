using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication14.Data.Migrations
{
    public partial class ChangeSensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerSensorId",
                table: "Sensor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerSensorId",
                table: "Sensor");
        }
    }
}
