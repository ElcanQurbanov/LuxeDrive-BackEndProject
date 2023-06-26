using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project_RentApp.Migrations
{
    public partial class AddIsMainProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "CarImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "CarImages");
        }
    }
}
