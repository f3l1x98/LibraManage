using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraManage.Migrations
{
    /// <inheritdoc />
    public partial class BookCopyCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfCopies",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfCopies",
                table: "Books");
        }
    }
}
