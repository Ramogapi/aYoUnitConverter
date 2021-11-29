using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aYo.Database.Migrations
{
    public partial class InitialDbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "Rate");

            migrationBuilder.CreateTable(
                name: "Imperial",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imperial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metric",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metric", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImperialRate",
                schema: "Rate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImperialId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetricId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImperialRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImperialRate_Imperial_ImperialId",
                        column: x => x.ImperialId,
                        principalSchema: "dbo",
                        principalTable: "Imperial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImperialRate_Metric_MetricId",
                        column: x => x.MetricId,
                        principalSchema: "dbo",
                        principalTable: "Metric",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetricRate",
                schema: "Rate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetricId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImperialId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetricRate_Imperial_ImperialId",
                        column: x => x.ImperialId,
                        principalSchema: "dbo",
                        principalTable: "Imperial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MetricRate_Metric_MetricId",
                        column: x => x.MetricId,
                        principalSchema: "dbo",
                        principalTable: "Metric",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImperialRate_ImperialId",
                schema: "Rate",
                table: "ImperialRate",
                column: "ImperialId");

            migrationBuilder.CreateIndex(
                name: "IX_ImperialRate_MetricId",
                schema: "Rate",
                table: "ImperialRate",
                column: "MetricId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricRate_ImperialId",
                schema: "Rate",
                table: "MetricRate",
                column: "ImperialId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricRate_MetricId",
                schema: "Rate",
                table: "MetricRate",
                column: "MetricId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImperialRate",
                schema: "Rate");

            migrationBuilder.DropTable(
                name: "MetricRate",
                schema: "Rate");

            migrationBuilder.DropTable(
                name: "Imperial",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Metric",
                schema: "dbo");
        }
    }
}
