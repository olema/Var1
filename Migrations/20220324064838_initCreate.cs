using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Var1.Migrations
{
    public partial class initCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doljn",
                columns: table => new
                {
                    WDoljnID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoljnName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doljn", x => x.WDoljnID);
                });

            migrationBuilder.CreateTable(
                name: "Oper",
                columns: table => new
                {
                    OperID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OperName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oper", x => x.OperID);
                });

            migrationBuilder.CreateTable(
                name: "Pacient",
                columns: table => new
                {
                    PacientID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MedPol = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacient", x => x.PacientID);
                });

            migrationBuilder.CreateTable(
                name: "WUser",
                columns: table => new
                {
                    WUserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DoljnForeignKey = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    Passw = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WUser", x => x.WUserID);
                    table.ForeignKey(
                        name: "FK_WUser_Doljn_DoljnForeignKey",
                        column: x => x.DoljnForeignKey,
                        principalTable: "Doljn",
                        principalColumn: "WDoljnID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emk",
                columns: table => new
                {
                    EmkID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InputDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    PacientID = table.Column<int>(type: "integer", nullable: false),
                    WUserID = table.Column<int>(type: "integer", nullable: false),
                    OperID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emk", x => x.EmkID);
                    table.ForeignKey(
                        name: "FK_Emk_Oper_OperID",
                        column: x => x.OperID,
                        principalTable: "Oper",
                        principalColumn: "OperID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emk_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "PacientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emk_WUser_WUserID",
                        column: x => x.WUserID,
                        principalTable: "WUser",
                        principalColumn: "WUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emk_OperID",
                table: "Emk",
                column: "OperID");

            migrationBuilder.CreateIndex(
                name: "IX_Emk_PacientID",
                table: "Emk",
                column: "PacientID");

            migrationBuilder.CreateIndex(
                name: "IX_Emk_WUserID",
                table: "Emk",
                column: "WUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WUser_DoljnForeignKey",
                table: "WUser",
                column: "DoljnForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emk");

            migrationBuilder.DropTable(
                name: "Oper");

            migrationBuilder.DropTable(
                name: "Pacient");

            migrationBuilder.DropTable(
                name: "WUser");

            migrationBuilder.DropTable(
                name: "Doljn");
        }
    }
}
