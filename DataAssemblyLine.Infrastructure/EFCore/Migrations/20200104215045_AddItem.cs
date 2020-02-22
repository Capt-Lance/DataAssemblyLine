using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAssemblyLine.Infrastructure.EFCore.Migrations
{
    public partial class AddItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CurrentData = table.Column<string>(nullable: true),
                    FailureMessage = table.Column<string>(nullable: true),
                    InitialData = table.Column<string>(nullable: true),
                    IsFailed = table.Column<bool>(nullable: false),
                    IsProcessed = table.Column<bool>(nullable: false),
                    LastCompletedStepId = table.Column<int>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ProcessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Steps_LastCompletedStepId",
                        column: x => x.LastCompletedStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_LastCompletedStepId",
                table: "Item",
                column: "LastCompletedStepId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
