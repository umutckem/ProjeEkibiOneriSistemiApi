using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeEkibiOneriSistemiApi.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseV301 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "desteks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Açıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlusturmaTarihi = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desteks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KullaniciRol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "yetkiler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OgrenciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yetkiler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "desteks");

            migrationBuilder.DropTable(
                name: "roller");

            migrationBuilder.DropTable(
                name: "yetkiler");
        }
    }
}
