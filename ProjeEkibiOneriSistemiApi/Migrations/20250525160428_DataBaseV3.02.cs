using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeEkibiOneriSistemiApi.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseV302 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminCevap",
                table: "desteks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "desteks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminCevap",
                table: "desteks");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "desteks");
        }
    }
}
