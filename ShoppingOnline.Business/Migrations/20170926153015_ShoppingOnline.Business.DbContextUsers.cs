﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShoppingOnline.Business.Migrations
{
    public partial class ShoppingOnlineBusinessDbContextUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityUserInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastLoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SessionToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityUserInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingUsers_SecurityUserInfos_SecurityInfoId",
                        column: x => x.SecurityInfoId,
                        principalTable: "SecurityUserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cap = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Cco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CivicNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prov = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingInfos_ShoppingUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ShoppingUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingInfos_UserId",
                table: "ShippingInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingUsers_SecurityInfoId",
                table: "ShoppingUsers",
                column: "SecurityInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShippingInfos");

            migrationBuilder.DropTable(
                name: "ShoppingUsers");

            migrationBuilder.DropTable(
                name: "SecurityUserInfos");
        }
    }
}
