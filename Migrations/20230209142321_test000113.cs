using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace loadxml.Migrations
{
    public partial class test000113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ED807BICDirectoryEntry",
                columns: table => new
                {
                    BIC = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ED807BICDirectoryEntry", x => x.BIC);
                });

            migrationBuilder.CreateTable(
                name: "ED807BICDirectoryEntryAccount",
                columns: table => new
                {
                    Account = table.Column<string>(type: "text", nullable: false),
                    RegulationAccountType = table.Column<string>(type: "text", nullable: true),
                    CK = table.Column<string>(type: "text", nullable: true),
                    AccountCBRBIC = table.Column<string>(type: "text", nullable: true),
                    DateIn = table.Column<string>(type: "text", nullable: true),
                    AccountStatus = table.Column<string>(type: "text", nullable: true),
                    DateOut = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ED807BICDirectoryEntryAccount", x => x.Account);
                });

            migrationBuilder.CreateTable(
                name: "ED807BICDirectoryEntryAccountsAccRstrList",
                columns: table => new
                {
                    AccRstr = table.Column<string>(type: "text", nullable: false),
                    AccRstrDate = table.Column<string>(type: "text", nullable: true),
                    ED807BICDirectoryEntryAccountsAccount = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ED807BICDirectoryEntryAccountsAccRstrList", x => x.AccRstr);
                    table.ForeignKey(
                        name: "FK_ED807BICDirectoryEntryAccountsAccRstrList_ED807BICDirectory~",
                        column: x => x.ED807BICDirectoryEntryAccountsAccount,
                        principalTable: "ED807BICDirectoryEntryAccount",
                        principalColumn: "Account");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ED807BICDirectoryEntryAccountsAccRstrList_ED807BICDirectory~",
                table: "ED807BICDirectoryEntryAccountsAccRstrList",
                column: "ED807BICDirectoryEntryAccountsAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ED807BICDirectoryEntry");

            migrationBuilder.DropTable(
                name: "ED807BICDirectoryEntryAccountsAccRstrList");

            migrationBuilder.DropTable(
                name: "ED807BICDirectoryEntryAccount");
        }
    }
}
