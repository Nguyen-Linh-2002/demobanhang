using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLBH.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    maKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dchi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nsinh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.maKH);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    maNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dchi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nvaolam = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.maNV);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    maSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DVT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaSP = table.Column<double>(type: "float", nullable: false),
                    giamgia = table.Column<double>(type: "float", nullable: false),
                    Lton = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.maSP);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    maHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nlap = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Ttien = table.Column<double>(type: "float", nullable: false),
                    maKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    maNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.maHD);
                    table.ForeignKey(
                        name: "FK_Inv_Cus",
                        column: x => x.maKH,
                        principalTable: "Customer",
                        principalColumn: "maKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inv_Emp",
                        column: x => x.maNV,
                        principalTable: "Employer",
                        principalColumn: "maNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    maHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    maSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sluong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => new { x.maHD, x.maSP });
                    table.ForeignKey(
                        name: "FK_IDetails_Inv",
                        column: x => x.maHD,
                        principalTable: "Invoice",
                        principalColumn: "maHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IDetails_Product",
                        column: x => x.maSP,
                        principalTable: "Product",
                        principalColumn: "maSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_maKH",
                table: "Invoice",
                column: "maKH");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_maNV",
                table: "Invoice",
                column: "maNV");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_maSP",
                table: "InvoiceDetails",
                column: "maSP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employer");
        }
    }
}
