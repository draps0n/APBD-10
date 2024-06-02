using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_10.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountsandCategoriestables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PK_Role",
                table: "Roles",
                newName: "PK_role");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    PK_account = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_role = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.PK_account);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_FK_role",
                        column: x => x.FK_role,
                        principalTable: "Roles",
                        principalColumn: "PK_role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    PK_category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.PK_category);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FK_role",
                table: "Accounts",
                column: "FK_role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.RenameColumn(
                name: "PK_role",
                table: "Roles",
                newName: "PK_Role");
        }
    }
}
