using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNDCatalog.Infrastructure.data.migrations
{
    public partial class SpellShortName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Spells",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Spells");
        }
    }
}
