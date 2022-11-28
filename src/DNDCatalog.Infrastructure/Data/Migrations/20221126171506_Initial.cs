using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNDCatalog.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameUa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NameRus = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DescriptionEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionUa1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionUa2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionUa3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionRu1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionRu2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CastingTime_IsAction = table.Column<bool>(type: "bit", nullable: true),
                    CastingTime_ActionTime_ActionType = table.Column<int>(type: "int", nullable: true),
                    CastingTime_ActionTime_Count = table.Column<int>(type: "int", nullable: true),
                    CastingTime_Time = table.Column<string>(type: "varchar(15)", nullable: true),
                    School = table.Column<int>(type: "int", nullable: true),
                    SaveReqired = table.Column<int>(type: "int", nullable: true),
                    Attack = table.Column<int>(type: "int", nullable: true),
                    DamageType = table.Column<int>(type: "int", nullable: true),
                    EffectType = table.Column<int>(type: "int", nullable: true),
                    Ritual = table.Column<bool>(type: "bit", nullable: false),
                    Concentration = table.Column<bool>(type: "bit", nullable: false),
                    ComponentV = table.Column<bool>(type: "bit", nullable: false),
                    ComponentS = table.Column<bool>(type: "bit", nullable: false),
                    ComponentM = table.Column<bool>(type: "bit", nullable: false),
                    ComponentMDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Range_Type = table.Column<int>(type: "int", nullable: true),
                    Range_Distance = table.Column<int>(type: "int", nullable: true),
                    Range_Area = table.Column<int>(type: "int", nullable: true),
                    Range_Shape = table.Column<int>(type: "int", nullable: true),
                    Duration_Type = table.Column<int>(type: "int", nullable: true),
                    Duration_Time = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Archetypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archetypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archetypes_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSpell",
                columns: table => new
                {
                    ClassesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpellsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSpell", x => new { x.ClassesId, x.SpellsId });
                    table.ForeignKey(
                        name: "FK_ClassSpell_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSpell_Spells_SpellsId",
                        column: x => x.SpellsId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellSpellTag",
                columns: table => new
                {
                    SpellsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSpellTag", x => new { x.SpellsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_SpellSpellTag_Spells_SpellsId",
                        column: x => x.SpellsId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellSpellTag_SpellTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "SpellTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchetypeSpell",
                columns: table => new
                {
                    ArchetypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpellsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchetypeSpell", x => new { x.ArchetypesId, x.SpellsId });
                    table.ForeignKey(
                        name: "FK_ArchetypeSpell_Archetypes_ArchetypesId",
                        column: x => x.ArchetypesId,
                        principalTable: "Archetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchetypeSpell_Spells_SpellsId",
                        column: x => x.SpellsId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archetypes_ClassId",
                table: "Archetypes",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchetypeSpell_SpellsId",
                table: "ArchetypeSpell",
                column: "SpellsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSpell_SpellsId",
                table: "ClassSpell",
                column: "SpellsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellSpellTag_TagsId",
                table: "SpellSpellTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchetypeSpell");

            migrationBuilder.DropTable(
                name: "ClassSpell");

            migrationBuilder.DropTable(
                name: "SpellSpellTag");

            migrationBuilder.DropTable(
                name: "Archetypes");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "SpellTags");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
