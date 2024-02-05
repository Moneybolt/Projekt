using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Regon = table.Column<string>(type: "TEXT", nullable: true),
                    Nip = table.Column<string>(type: "TEXT", nullable: true),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "travel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Start_Date = table.Column<string>(type: "TEXT", nullable: true),
                    End_Date = table.Column<string>(type: "TEXT", nullable: true),
                    Start_Place = table.Column<string>(type: "TEXT", nullable: true),
                    End_Place = table.Column<string>(type: "TEXT", nullable: true),
                    Participants = table.Column<int>(type: "INTEGER", nullable: false),
                    Guide = table.Column<string>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_travel_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "Nip", "Regon", "Title", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[,]
                {
                    { 101, "123123", "14124", "Test", "Kraków", "31-150", "Św.Filipa 17" },
                    { 102, "12431", "12412f", "Testowy", "Rzeszów", "39-200", "Hetmańska 12" }
                });

            migrationBuilder.InsertData(
                table: "travel",
                columns: new[] { "Id", "End_Date", "End_Place", "Guide", "Name", "OrganizationId", "Participants", "Start_Date", "Start_Place" },
                values: new object[,]
                {
                    { 1, "2018-07-11", "Praga", "Szymon", "Test", 101, 27, "2014-12-12", "Kraków" },
                    { 2, null, null, "Jarosław", "Nazwa", 102, 49, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_travel_OrganizationId",
                table: "travel",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "travel");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
