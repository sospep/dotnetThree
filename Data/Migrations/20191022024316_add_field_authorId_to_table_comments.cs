using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetThree.Data.Migrations
{
    public partial class add_field_authorId_to_table_comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Comment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Comment");
        }
    }
}
