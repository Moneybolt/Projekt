using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Laptop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "51530fc6-020f-47dd-9870-d08ac3e3864f", "1a358f33-61b6-44a9-99d9-2c91aa7a5c8f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82279860-c631-4f9b-91f2-0f1068a745c5", "e81782e5-a60a-467e-8b00-4ce7827235f7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51530fc6-020f-47dd-9870-d08ac3e3864f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82279860-c631-4f9b-91f2-0f1068a745c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a358f33-61b6-44a9-99d9-2c91aa7a5c8f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e81782e5-a60a-467e-8b00-4ce7827235f7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b4e3b21-e5b0-4e48-a6b3-739cdc3e0c1f", "9b4e3b21-e5b0-4e48-a6b3-739cdc3e0c1f", "admin", "ADMIN" },
                    { "e85a757b-aea1-4cc8-8b7d-95898de99231", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a013a2b9-8b76-4f85-bb33-e8b1763dfd5f", 0, "04d9b9af-d104-453e-b7a9-35a3664539be", "normal@wsei.pl", true, false, null, "NORMAL@WSEI.PL", "NORMAL", "AQAAAAIAAYagAAAAEKapKe4oul+irMmqD1Q7x8LRuPqsoJVN6CK59EhEVrdH4ZlV3PFQLZQlMSN+G6AJsg==", null, false, "17d565eb-c7fb-4442-80b4-239230babe17", false, "normal" },
                    { "dd725021-bd14-4091-a089-b8bd03cc677e", 0, "86be1873-5e03-4fae-8565-efd4184420c5", "test@wsei.pl", true, false, null, "TEST@WSEI.PL", "TEST", "AQAAAAIAAYagAAAAEJYmGm9yUclXC4pMhGmKPcqBra6k0FRu0zT3JoXMYK4Ld+ZfwdoMRibmjlzeV4O8+w==", null, false, "f5701b2c-cbab-4081-8876-143cd155b360", false, "test" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e85a757b-aea1-4cc8-8b7d-95898de99231", "a013a2b9-8b76-4f85-bb33-e8b1763dfd5f" },
                    { "9b4e3b21-e5b0-4e48-a6b3-739cdc3e0c1f", "dd725021-bd14-4091-a089-b8bd03cc677e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e85a757b-aea1-4cc8-8b7d-95898de99231", "a013a2b9-8b76-4f85-bb33-e8b1763dfd5f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b4e3b21-e5b0-4e48-a6b3-739cdc3e0c1f", "dd725021-bd14-4091-a089-b8bd03cc677e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b4e3b21-e5b0-4e48-a6b3-739cdc3e0c1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e85a757b-aea1-4cc8-8b7d-95898de99231");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a013a2b9-8b76-4f85-bb33-e8b1763dfd5f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dd725021-bd14-4091-a089-b8bd03cc677e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51530fc6-020f-47dd-9870-d08ac3e3864f", null, "user", "USER" },
                    { "82279860-c631-4f9b-91f2-0f1068a745c5", "82279860-c631-4f9b-91f2-0f1068a745c5", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a358f33-61b6-44a9-99d9-2c91aa7a5c8f", 0, "a65f5aa3-9865-432c-8465-50cabb1b3443", "normal@wsei.pl", true, false, null, "NORMAL@WSEI.PL", "NORMAL", "AQAAAAIAAYagAAAAEJ4+ON+Q/QIMs9CFb6X1zdlDtL3ruMDWASyYd++6o0wb/13dWC1CkdJpxd5eZQ77zQ==", null, false, "9584673f-b40b-4f06-aa1a-08e47c8a0e48", false, "normal" },
                    { "e81782e5-a60a-467e-8b00-4ce7827235f7", 0, "684f45df-891a-4b8c-8ba2-e68b07b1bd77", "test@wsei.pl", true, false, null, "TEST@WSEI.PL", "TEST", "AQAAAAIAAYagAAAAEHqgm5lZgDkt+NUnpLyaB52Ephxmrt1KdzOFJtRUOGxHe7kWKiQwTInsYQnwRBQd8Q==", null, false, "b37451b8-9776-4179-ab13-747af6a89bf5", false, "test" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "51530fc6-020f-47dd-9870-d08ac3e3864f", "1a358f33-61b6-44a9-99d9-2c91aa7a5c8f" },
                    { "82279860-c631-4f9b-91f2-0f1068a745c5", "e81782e5-a60a-467e-8b00-4ce7827235f7" }
                });
        }
    }
}
