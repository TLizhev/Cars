﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.Data.Migrations
{
    public partial class DealersUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Dealer_DealerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Dealer_AspNetUsers_UserId",
                table: "Dealer");

            migrationBuilder.DropForeignKey(
                name: "FK_Dealer_AspNetUsers_UserId1",
                table: "Dealer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dealer",
                table: "Dealer");

            migrationBuilder.RenameTable(
                name: "Dealer",
                newName: "Dealers");

            migrationBuilder.RenameIndex(
                name: "IX_Dealer_UserId1",
                table: "Dealers",
                newName: "IX_Dealers_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dealer_UserId",
                table: "Dealers",
                newName: "IX_Dealers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dealers",
                table: "Dealers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Dealers_DealerId",
                table: "Cars",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_AspNetUsers_UserId",
                table: "Dealers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_AspNetUsers_UserId1",
                table: "Dealers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Dealers_DealerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_AspNetUsers_UserId",
                table: "Dealers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_AspNetUsers_UserId1",
                table: "Dealers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dealers",
                table: "Dealers");

            migrationBuilder.RenameTable(
                name: "Dealers",
                newName: "Dealer");

            migrationBuilder.RenameIndex(
                name: "IX_Dealers_UserId1",
                table: "Dealer",
                newName: "IX_Dealer_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Dealers_UserId",
                table: "Dealer",
                newName: "IX_Dealer_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dealer",
                table: "Dealer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Dealer_DealerId",
                table: "Cars",
                column: "DealerId",
                principalTable: "Dealer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dealer_AspNetUsers_UserId",
                table: "Dealer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dealer_AspNetUsers_UserId1",
                table: "Dealer",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
