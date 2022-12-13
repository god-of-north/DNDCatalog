using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNDCatalog.Infrastructure.data.migrations
{
    public partial class MagicItemsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MagicItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameUa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NameRus = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DescriptionUa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionUa1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionUa2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionRus1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionRus2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Attunement = table.Column<bool>(type: "bit", nullable: false),
                    MagicBonus = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Consumable = table.Column<bool>(type: "bit", nullable: false),
                    Charged = table.Column<bool>(type: "bit", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Price_MinPrice = table.Column<int>(type: "int", nullable: true),
                    Price_MaxPrice = table.Column<int>(type: "int", nullable: true),
                    Price_Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price_Formula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HashtagMagicItem",
                columns: table => new
                {
                    HashtagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagicItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashtagMagicItem", x => new { x.HashtagsId, x.MagicItemsId });
                    table.ForeignKey(
                        name: "FK_HashtagMagicItem_Hashtags_HashtagsId",
                        column: x => x.HashtagsId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HashtagMagicItem_MagicItems_MagicItemsId",
                        column: x => x.MagicItemsId,
                        principalTable: "MagicItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HashtagMagicItem_MagicItemsId",
                table: "HashtagMagicItem",
                column: "MagicItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HashtagMagicItem");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "MagicItems");
        }
    }
}
