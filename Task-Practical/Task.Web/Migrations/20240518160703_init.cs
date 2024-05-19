using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.Web.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_Service_Tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Service_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corporate_Customer_Tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporate_Customer_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corporate_Customer_Tbl_Customers_Id",
                        column: x => x.Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Individual_Customer_Tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individual_Customer_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individual_Customer_Tbl_Customers_Id",
                        column: x => x.Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meeting_Minutes_Master_Tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingAgenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingDiscussion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendsFromClientSide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendsFromHostSide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingDecision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting_Minutes_Master_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Master_Tbl_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meeting_Minutes_Details_Tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductorServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting_Minutes_Details_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Details_Tbl_Meeting_Minutes_Master_Tbl_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting_Minutes_Master_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Details_Tbl_Products_Service_Tbl_ProductorServiceId",
                        column: x => x.ProductorServiceId,
                        principalTable: "Products_Service_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_MeetingId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_ProductorServiceId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "ProductorServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Master_Tbl_CustomerId",
                table: "Meeting_Minutes_Master_Tbl",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corporate_Customer_Tbl");

            migrationBuilder.DropTable(
                name: "Individual_Customer_Tbl");

            migrationBuilder.DropTable(
                name: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropTable(
                name: "Meeting_Minutes_Master_Tbl");

            migrationBuilder.DropTable(
                name: "Products_Service_Tbl");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
