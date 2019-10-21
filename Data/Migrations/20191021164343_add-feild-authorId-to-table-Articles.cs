using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetThree.Data.Migrations
{
    public partial class addfeildauthorIdtotableArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Article",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Article");
        }
    }
}
