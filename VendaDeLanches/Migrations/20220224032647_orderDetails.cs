﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaDeLanches.Migrations
{
    public partial class orderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endereco = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Complement = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Cep = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    State = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    City = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Phone = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    Email = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    TotalOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalOrderItens = table.Column<int>(type: "int", nullable: false),
                    SentOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDeliveredIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SnackId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailsId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SnackId",
                table: "OrderDetails",
                column: "SnackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
