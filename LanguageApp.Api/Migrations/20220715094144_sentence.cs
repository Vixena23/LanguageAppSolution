using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageApp.Api.Migrations
{
    public partial class sentence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "CategoryId", "OryginalText", "TagId", "TranslateText" },
                values: new object[] { 1, 1, "test1", 1, "red" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
