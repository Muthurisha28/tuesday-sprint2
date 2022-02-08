using Microsoft.EntityFrameworkCore.Migrations;

namespace CBMS.DAL.Migrations
{
    public partial class addingtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "busdetails",
                columns: table => new
                {
                    busNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    busName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    arrivalTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_busdetails", x => x.busNo);
                });

            migrationBuilder.CreateTable(
                name: "busstop",
                columns: table => new
                {
                    busStopNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    arrivalTime = table.Column<int>(type: "int", nullable: false),
                    depatureTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_busstop", x => x.busStopNo);
                });

            migrationBuilder.CreateTable(
                name: "routedetails",
                columns: table => new
                {
                    routeNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routedetails", x => x.routeNo);
                });

            migrationBuilder.CreateTable(
                name: "BusStopRouteDetails",
                columns: table => new
                {
                    busStopNo = table.Column<int>(type: "int", nullable: false),
                    routeDetailsrouteNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStopRouteDetails", x => new { x.busStopNo, x.routeDetailsrouteNo });
                    table.ForeignKey(
                        name: "FK_BusStopRouteDetails_busstop_busStopNo",
                        column: x => x.busStopNo,
                        principalTable: "busstop",
                        principalColumn: "busStopNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusStopRouteDetails_routedetails_routeDetailsrouteNo",
                        column: x => x.routeDetailsrouteNo,
                        principalTable: "routedetails",
                        principalColumn: "routeNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trip",
                columns: table => new
                {
                    tripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tripCount = table.Column<int>(type: "int", nullable: false),
                    busDetailsbusNo = table.Column<int>(type: "int", nullable: true),
                    routeDetailsrouteNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trip", x => x.tripId);
                    table.ForeignKey(
                        name: "FK_trip_busdetails_busDetailsbusNo",
                        column: x => x.busDetailsbusNo,
                        principalTable: "busdetails",
                        principalColumn: "busNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trip_routedetails_routeDetailsrouteNo",
                        column: x => x.routeDetailsrouteNo,
                        principalTable: "routedetails",
                        principalColumn: "routeNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    empType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tripDetailstripId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.empId);
                    table.ForeignKey(
                        name: "FK_employee_trip_tripDetailstripId",
                        column: x => x.tripDetailstripId,
                        principalTable: "trip",
                        principalColumn: "tripId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusStopRouteDetails_routeDetailsrouteNo",
                table: "BusStopRouteDetails",
                column: "routeDetailsrouteNo");

            migrationBuilder.CreateIndex(
                name: "IX_employee_tripDetailstripId",
                table: "employee",
                column: "tripDetailstripId");

            migrationBuilder.CreateIndex(
                name: "IX_trip_busDetailsbusNo",
                table: "trip",
                column: "busDetailsbusNo");

            migrationBuilder.CreateIndex(
                name: "IX_trip_routeDetailsrouteNo",
                table: "trip",
                column: "routeDetailsrouteNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusStopRouteDetails");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "busstop");

            migrationBuilder.DropTable(
                name: "trip");

            migrationBuilder.DropTable(
                name: "busdetails");

            migrationBuilder.DropTable(
                name: "routedetails");
        }
    }
}
