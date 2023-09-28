using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _004_EF.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompnyEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompnyPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mobiles",
                columns: table => new
                {
                    Ident = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobiles", x => x.Ident);
                    table.ForeignKey(
                        name: "FK_Mobiles_Manufacturies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Manufacturies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_CompanyId",
                table: "Mobiles",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mobiles");

            migrationBuilder.DropTable(
                name: "Manufacturies");
        }
    }
}
