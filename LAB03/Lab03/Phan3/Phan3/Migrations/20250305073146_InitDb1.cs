using Microsoft.EntityFrameworkCore.Migrations;

namespace Phan3.Migrations
{
    public partial class InitDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pages",
                table: "Book",
                newName: "NumberOfPages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfPages",
                table: "Book",
                newName: "Pages");
        }
    }
}
