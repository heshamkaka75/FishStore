using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishStore.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    BoatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoatName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Manger = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.BoatId);
                });

            migrationBuilder.CreateTable(
                name: "Fishs",
                columns: table => new
                {
                    FishID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishs", x => x.FishID);
                });

            migrationBuilder.CreateTable(
                name: "AgentOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentNo = table.Column<int>(type: "int", nullable: false),
                    FishNo = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_AgentOrders_Agents_AgentNo",
                        column: x => x.AgentNo,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentOrders_Fishs_FishNo",
                        column: x => x.FishNo,
                        principalTable: "Fishs",
                        principalColumn: "FishID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CenterFishAgencies",
                columns: table => new
                {
                    CFA_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    FishNo = table.Column<int>(type: "int", nullable: false),
                    BoatNo = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterFishAgencies", x => x.CFA_id);
                    table.ForeignKey(
                        name: "FK_CenterFishAgencies_Boats_BoatNo",
                        column: x => x.BoatNo,
                        principalTable: "Boats",
                        principalColumn: "BoatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CenterFishAgencies_Fishs_FishNo",
                        column: x => x.FishNo,
                        principalTable: "Fishs",
                        principalColumn: "FishID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentOrders_AgentNo",
                table: "AgentOrders",
                column: "AgentNo");

            migrationBuilder.CreateIndex(
                name: "IX_AgentOrders_FishNo",
                table: "AgentOrders",
                column: "FishNo");

            migrationBuilder.CreateIndex(
                name: "IX_CenterFishAgencies_BoatNo",
                table: "CenterFishAgencies",
                column: "BoatNo");

            migrationBuilder.CreateIndex(
                name: "IX_CenterFishAgencies_FishNo",
                table: "CenterFishAgencies",
                column: "FishNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentOrders");

            migrationBuilder.DropTable(
                name: "CenterFishAgencies");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "Fishs");
        }
    }
}
