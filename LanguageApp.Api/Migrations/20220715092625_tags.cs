using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageApp.Api.Migrations
{
    public partial class tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Color", "Description", "Name" },
                values: new object[] { 1, "red", "test tag 1", "test1" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Color", "Description", "Name" },
                values: new object[] { 2, "green", "test tag 2", "test2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
