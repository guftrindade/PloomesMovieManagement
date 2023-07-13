using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Management.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    DirectedBy = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Year = table.Column<short>(type: "SMALLINT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
