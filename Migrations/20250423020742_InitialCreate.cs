using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriorAuthPrototype.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriorAuthorizationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientName = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderName = table.Column<string>(type: "TEXT", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProcedureCode = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    IsUrgent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorAuthorizationRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriorAuthorizationRequests");
        }
    }
}
