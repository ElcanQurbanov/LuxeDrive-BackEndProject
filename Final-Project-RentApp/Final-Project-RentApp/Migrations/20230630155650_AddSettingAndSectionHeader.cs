using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project_RentApp.Migrations
{
    public partial class AddSettingAndSectionHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCategory_Cars_CarId",
                table: "CarCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CarCategory_Category_CategoryId",
                table: "CarCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CarTag_Cars_CarId",
                table: "CarTag");

            migrationBuilder.DropForeignKey(
                name: "FK_CarTag_Tags_TagId",
                table: "CarTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarTag",
                table: "CarTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarCategory",
                table: "CarCategory");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "CarTag",
                newName: "CarTags");

            migrationBuilder.RenameTable(
                name: "CarCategory",
                newName: "CarCategories");

            migrationBuilder.RenameIndex(
                name: "IX_CarTag_TagId",
                table: "CarTags",
                newName: "IX_CarTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_CarTag_CarId",
                table: "CarTags",
                newName: "IX_CarTags_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarCategory_CategoryId",
                table: "CarCategories",
                newName: "IX_CarCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CarCategory_CarId",
                table: "CarCategories",
                newName: "IX_CarCategories_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarTags",
                table: "CarTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarCategories",
                table: "CarCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SectionHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CarCategories_Cars_CarId",
                table: "CarCategories",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarCategories_Categories_CategoryId",
                table: "CarCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarTags_Cars_CarId",
                table: "CarTags",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarTags_Tags_TagId",
                table: "CarTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCategories_Cars_CarId",
                table: "CarCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_CarCategories_Categories_CategoryId",
                table: "CarCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_CarTags_Cars_CarId",
                table: "CarTags");

            migrationBuilder.DropForeignKey(
                name: "FK_CarTags_Tags_TagId",
                table: "CarTags");

            migrationBuilder.DropTable(
                name: "SectionHeaders");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarTags",
                table: "CarTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarCategories",
                table: "CarCategories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "CarTags",
                newName: "CarTag");

            migrationBuilder.RenameTable(
                name: "CarCategories",
                newName: "CarCategory");

            migrationBuilder.RenameIndex(
                name: "IX_CarTags_TagId",
                table: "CarTag",
                newName: "IX_CarTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_CarTags_CarId",
                table: "CarTag",
                newName: "IX_CarTag_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarCategories_CategoryId",
                table: "CarCategory",
                newName: "IX_CarCategory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CarCategories_CarId",
                table: "CarCategory",
                newName: "IX_CarCategory_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarTag",
                table: "CarTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarCategory",
                table: "CarCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarCategory_Cars_CarId",
                table: "CarCategory",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarCategory_Category_CategoryId",
                table: "CarCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarTag_Cars_CarId",
                table: "CarTag",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarTag_Tags_TagId",
                table: "CarTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
