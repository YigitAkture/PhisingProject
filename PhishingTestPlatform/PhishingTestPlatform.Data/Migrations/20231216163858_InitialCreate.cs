using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhishingTestPlatform.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TemplateSubject = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TemplateBody = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhishingEmailsSend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsClicked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhishingEmailsSend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhishingEmailsSend_EmailTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhishingInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CreditCardExpirationDateMonth = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    CreditCardExpirationDateYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CreditCardCVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PhishingEmailSendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhishingInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhishingInfo_PhishingEmailsSend_PhishingEmailSendId",
                        column: x => x.PhishingEmailSendId,
                        principalTable: "PhishingEmailsSend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhishingEmailsSend_TemplateId",
                table: "PhishingEmailsSend",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PhishingInfo_PhishingEmailSendId",
                table: "PhishingInfo",
                column: "PhishingEmailSendId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhishingInfo");

            migrationBuilder.DropTable(
                name: "PhishingEmailsSend");

            migrationBuilder.DropTable(
                name: "EmailTemplates");
        }
    }
}
