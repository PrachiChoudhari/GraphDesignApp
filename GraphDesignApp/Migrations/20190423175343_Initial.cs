using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphDesignApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.EmailAddress);
                });

            migrationBuilder.CreateTable(
                name: "GraphicDesigns",
                columns: table => new
                {
                    GraphicDesignId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignType = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    PaperQuality = table.Column<int>(nullable: false),
                    ShippingType = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicDesigns", x => x.GraphicDesignId);
                    table.ForeignKey(
                        name: "FK_GraphicDesigns_UserAccounts_EmailAddress",
                        column: x => x.EmailAddress,
                        principalTable: "UserAccounts",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GraphicDesigns_EmailAddress",
                table: "GraphicDesigns",
                column: "EmailAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GraphicDesigns");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
