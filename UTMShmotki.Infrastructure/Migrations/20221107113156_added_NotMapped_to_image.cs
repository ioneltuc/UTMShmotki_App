using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UTMShmotki.Infrastructure.Migrations
{
    public partial class added_NotMapped_to_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
