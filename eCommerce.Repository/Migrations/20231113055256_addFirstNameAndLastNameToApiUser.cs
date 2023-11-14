using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerce.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addFirstNameAndLastNameToApiUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44ecaa7d-d46d-4992-99c5-39a3f382cebf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c33cb665-6d41-4daf-a074-f721e9d9aeac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbf8c4ef-4e98-4bab-a0cb-3ae48d22c571");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44ecaa7d-d46d-4992-99c5-39a3f382cebf", "9ae77758-dd6c-4797-a1e3-feef68cad66c", "customer", "CUSTOMER" },
                    { "c33cb665-6d41-4daf-a074-f721e9d9aeac", "cb4c7829-7060-4c05-a14b-1fb43bccc5e5", "seller", "SELLER" },
                    { "dbf8c4ef-4e98-4bab-a0cb-3ae48d22c571", "25478add-46d1-4525-9ddd-7de0f2d76eed", "admin", "ADMIN" }
                });
        }
    }
}
