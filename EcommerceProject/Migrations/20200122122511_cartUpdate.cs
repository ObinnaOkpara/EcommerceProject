using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceProject.Migrations
{
    public partial class cartUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Carts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Carts");
        }
    }
}
