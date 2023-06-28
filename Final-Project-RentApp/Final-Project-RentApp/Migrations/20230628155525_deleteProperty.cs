using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project_RentApp.Migrations
{
    public partial class deleteProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_CarClasses_CarClassId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CarClassId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CarClassId",
                table: "Blogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarClassId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CarClassId",
                table: "Blogs",
                column: "CarClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_CarClasses_CarClassId",
                table: "Blogs",
                column: "CarClassId",
                principalTable: "CarClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
