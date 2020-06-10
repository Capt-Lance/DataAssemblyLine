using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAssemblyLine.Infrastructure.EFCore.Migrations
{
    public partial class AddProccessIdFKToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Item_ProcessId",
                table: "Item",
                column: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Processes_ProcessId",
                table: "Item",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Processes_ProcessId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_ProcessId",
                table: "Item");
        }
    }
}
