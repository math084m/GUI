using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNET_SmartCity_MathiasThomassen_201706287.Data.Migrations
{
    public partial class InitialSensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    SensorId = table.Column<string>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    TreeSort = table.Column<string>(nullable: true),
                    lat = table.Column<double>(nullable: false),
                    lon = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.SensorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensor");
        }
    }
}
